using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Stat")]
public class ObjectStat : ScriptableObject
{
    [SerializeField] private float _hp;
    public float HP
    {
        get
        {
            return _hp;
        }
        set
        {
            _hp = value;
        }
    }

    [SerializeField] private float _atk;
    public float ATK
    {
        get
        {
            return _atk;
        }
        set
        {
            _atk = value;
        }
    }

    [SerializeField] private float _def;
    public float DEF 
    {
        get
        {
            return _def;
        }
        set
        {
            _def = value;
        }
    }


    [SerializeField] private float _speed;
    /// <summary>
    /// 계수
    /// </summary>
    public float SPEED 
    {
        get
        {
            return _speed;
        }
        set
        {
            _speed = value;
        }
    }

    [SerializeField] private float _crit;
    public float Crit
    {
        get
        {
            return _crit;
        }
        set
        {
            _crit = value;
        }
    }


    [SerializeField] private float _critAmp;
    /// <summary>
    /// 계수
    /// </summary>
    public float CritAmp
    {
        get
        {
            return _critAmp;
        }
        set
        {
            _crit = value;
        }
    }

    [SerializeField] private float _coolTime;
    /// <summary>
    /// 스킬 쿨타임
    /// </summary>
    public float COOLDOWN
    {
        get
        {
            return _coolTime;
        }
        set
        {
            _coolTime = value;
        }
    }
    
}