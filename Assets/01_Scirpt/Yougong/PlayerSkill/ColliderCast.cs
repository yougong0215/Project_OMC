using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public abstract class ColliderCast : MonoBehaviour
{
    protected Collider[] cols;
    [Header("SkillSO")]
    [SerializeField] SkillSO _skill;

    public SkillSO SkillSO => _skill;
    
    [Header("Layer")]
    public LayerMask _layer;

    public Action<Collider> CastAct;
    public Action OnAnimEvnt;
    
    
    protected CharacterInfo _player;

    private bool isAttack = false;
    private bool ColliderEnd = false;

    public bool IsAttack => isAttack;

    private void OnEnable()
    {
        isAttack = false;
        ColliderEnd = false;
    }

    public void Init(CharacterInfo Player, ObjectStat Weapon)
    {
        _player = Player;
        _skill.Init(_player, Weapon, this);
        transform.parent = null;
    }

    public void Attack(bool b)
    {
        isAttack = b;
        if (b == false)
        {
            ColliderEnd = true;
        }
        else
        {
            
            OnAnimEvnt?.Invoke();
        }
    }
    

    public bool ReturnEnd()
    {
        return ColliderEnd;
    }
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
    
    
    protected void Update()
    {
        //        Debug.Log(IsAttack);
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

            CastAct?.Invoke(col);
            Debug.Log($"{col.name} 맞음");

        }
    }
}
