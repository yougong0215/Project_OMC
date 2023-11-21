using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

public abstract class ColliderCast : PoolAble
{
    protected Collider[] cols;
    [Header("SkillSO")]
    [SerializeField] SkillSO _skill;

    [SerializeField] private List<ColliderSkillAction> _act = new();
    public Vector3 originVec;
    
    public SkillSO SkillSO => _skill;
    
    [Header("Layer")]
    public LayerMask _layer;

    public Action<Collider, bool> CastAct;
    public Action OnAnimEvnt;
    public Action OnAnimEnd;


    public CharacterInfo _player;

    private bool isAttack = false;
    private bool ColliderEnd = false;
    
    /// <summary>
    /// 중복 방지용
    /// </summary>
    [SerializeField] public Dictionary<Collider, bool> CheckDic = new();
    


    /// <summary>
    /// 콜라이더 형에 따라주기 =>
    /// Switch는 가독성이 심각하게 떨어지는거 같고
    /// 인스팩터에서 햇갈려서 이리함
    /// </summary>
    /// <returns></returns>
    public abstract Collider[] ReturnColliders();

    public bool IsAttack => isAttack;

    protected virtual void Awake()
    {
        originVec = transform.localPosition;
    }

    public override void Reset()
    {
        CastAct = null;
        OnAnimEvnt = null;
        OnAnimEnd = null;
        isAttack = false;
        ColliderEnd = false;
    }

    public void DeleteSeqeunce()
    {
        Destroy(this.gameObject);
    }

    public void Init(CharacterInfo Player, ObjectStatSO Weapon)
    {
        _player = Player;
        _skill.Init(_player, Weapon, this);
        //transform.localPosition += originVec;
        transform.SetParent(null);
        //originVec = transform.position;
        
            Debug.Log("Reset try");
            
        _act = GetComponentsInChildren<ColliderSkillAction>().ToList();
        foreach (var a in _act)
        {
            a.Reset(this,transform);
        }
    }

    public void Attack(bool b)
    {
        //Debug.Log(b);
        isAttack = b;
        if (b == false)
        {
            ColliderEnd = true;
            OnAnimEnd?.Invoke();
        }
        else
        {
            
            OnAnimEvnt?.Invoke();
        }
    }
    

    public bool ReturnColliderEnd()
    {
        return ColliderEnd;
    }

    private float _check = 0;
    
    
    protected void Update()
    {
        
        if (ColliderEnd == false)
        {
            _skill.SkillUpdate();
        }
        
        if (isAttack == true)
        {
            _check += Time.deltaTime;
        }

        if (_check >= 3f)
        {
            Destroy(this.gameObject);
        }
        
        
        if (!isAttack)
            return;

        cols = ReturnColliders();
        // 생각해 봤는데 어차피 col있는 만큼만 돌아가기 때문에 큰 문제 없음
        foreach (var col in cols)
        {
            if (CheckDic.ContainsKey(col))
                return;
            else
                CheckDic.Add(col, false);
            Debug.Log("이밴트 시작");
            Debug.Log(col.gameObject.name);
            CastAct?.Invoke(col, true);
            //Debug.Log($"{col.name} 맞음");

        }
    }
}
