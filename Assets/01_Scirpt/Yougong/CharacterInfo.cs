using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class CharacterInfo : PoolAble
{
    [Header("IsNuckBack ( false = 넉백 되는 상태 )")]
    [SerializeField] private bool _isNuckbackAble = true;

    public bool IsNuckBackAble => _isNuckbackAble;
    

    public override void Reset()
    {
        _stat = new ObjectStat();
        _stat.SetStat(statSo);
    }
    
    [SerializeField] private FSM _fsm;
    public FSM FSM => _fsm;

    [SerializeField] private AnimationController _con;
    [NonSerialized] protected bool _isDamaged = false;
    public bool IsDamage => _isDamaged;
    [SerializeField] private float _dmgTime = 0f;
    [SerializeField] private HitDissolve _hit;
    public HitDissolve HitDis=> _hit;

    public AnimationController AnimCon
    {
        get
        {
            if (_con == null)
            {

                _con = GetComponentInChildren<AnimationController>();
            }

            return _con;

        }
    }

    protected Coroutine _co = null;

    protected virtual void AwakeInvoke()
    {

    }
    
    void Awake()
    {
        _fsm = GetComponentInChildren<FSM>();
        _hit = GetComponentInChildren<HitDissolve>();
        _stat = new ObjectStat();
        _stat.SetStat(statSo);
        
        
        AwakeInvoke();
    }
    
    [FormerlySerializedAs("_stat")] [SerializeField] protected ObjectStatSO statSo;

    private ObjectStat _stat;
    public ObjectStat Stat => _stat;

    /// <summary>
    /// 몬스터에 기믹이 있다면 override 하기
    /// </summary>
    public virtual void GetDamage(float _damage, bool _nuckBack = true)
    {
        statSo.HP -= (int)_damage;
        if(_co == null)
            _co = StartCoroutine(Damaged());

        if (_nuckBack)
        {
            
            if (HitDis != null)
            {
                Debug.Log("hit");
                HitDis.StartHiting();
            }
            
            // 적 정보 받아서 넉백 스테이트 Hit 변경
        }
    }

    public IEnumerator Damaged()
    {
        _isDamaged = true;
        yield return new WaitForSeconds(_dmgTime);
        _isDamaged = false;
        _co = null;
    }
    
}
