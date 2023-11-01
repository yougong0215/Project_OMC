using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterInfo : MonoBehaviour
{

    private FSM _fsm;
    public FSM FSM => _fsm;

    private AnimationController _con;

    public AnimationController AnimCon => _con;
    private void Awake()
    {
        _fsm = GetComponentInChildren<FSM>();
        _con = GetComponentInChildren<AnimationController>();
    }
    
    [SerializeField] ObjectStat _stat;

    public ObjectStat Stat
    {
        get
        {
            if (_stat == null)
            {
                Debug.LogError("ChracterStat is Missing");
                return null;
            }

            return _stat;
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
        _stat.HP -= _damage;
    }
    


}
