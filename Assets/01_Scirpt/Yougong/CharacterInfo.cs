using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class CharacterInfo : PoolAble
{

    public override void Reset()
    {
        
    }
    
    [SerializeField] private FSM _fsm;
    public FSM FSM => _fsm;

    [SerializeField] private AnimationController _con;
    [NonSerialized] protected bool _isDamaged = false;
    public bool IsDamage => _isDamaged;
    [SerializeField] private float _dmgTime = 0f;

    public AnimationController AnimCon => _con;

    protected Coroutine _co = null;

    protected virtual void AwakeInvoke()
    {
        _stat = new ObjectStat();
        _stat.SetStat(statSo);
    }
    
    void Awake()
    {
        _fsm = GetComponentInChildren<FSM>();
        _con = GetComponentInChildren<AnimationController>();

        AwakeInvoke();
    }
    
    [FormerlySerializedAs("_stat")] [SerializeField] protected ObjectStatSO statSo;

    private ObjectStat _stat;
    public ObjectStat Stat => _stat;

    /// <summary>
    /// 몬스터에 기믹이 있다면 override 하기
    /// </summary>
    public virtual void GetDamage(float _damage)
    {
        statSo.HP -= (int)_damage;
        if(_co == null)
            _co = StartCoroutine(Damaged());
    }

    public IEnumerator Damaged()
    {
        _isDamaged = true;
        yield return new WaitForSeconds(_dmgTime);
        _isDamaged = false;
        _co = null;
    }
    
}
