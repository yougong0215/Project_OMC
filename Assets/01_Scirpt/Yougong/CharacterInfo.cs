using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class CharacterInfo : MonoBehaviour
{

    [SerializeField] private FSM _fsm;
    public FSM FSM => _fsm;

    [SerializeField] private AnimationController _con;

    public AnimationController AnimCon => _con;

    protected virtual void AwakeInvoke()
    {
        
    }
    
    void Awake()
    {
        _fsm = GetComponentInChildren<FSM>();
        _con = GetComponentInChildren<AnimationController>();
        AwakeInvoke();
    }
    
    [FormerlySerializedAs("_stat")] [SerializeField] protected ObjectStatSO statSo;

    public ObjectStatSO StatSo
    {
        get
        {
            if (statSo == null)
            {
                Debug.LogError("ChracterStat is Missing");
                return null;
            }

            return statSo;
        }
        protected set
        {
            
        }
    }

    /// <summary>
    /// 몬스터에 기믹이 있다면 override 하기
    /// </summary>
    public virtual void GetDamage(float _damage)
    {
        statSo.HP -= (int)_damage;
    }
    


}
