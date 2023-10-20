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
    
    
    [Header("Layer")]
    public LayerMask _layer;

    public Action<Collider> CastAct;
    
    
    protected float _playerDamage;
    protected Transform _player;
    public void Init(Transform Player, float Damage)
    {
        _player = Player;
        _playerDamage = Damage;
    }
    
    /// <summary>
    /// 중복 방지용
    /// </summary>
    [SerializeField] protected Dictionary<Collider, bool> CheckDic = new();

    
    /// <summary>
    /// 콜라이더 형에 따라주기 =>
    /// Switch는 가독성이 심각하게 떨어지는거 같고
    /// 인스팩터에서 햇갈려서 이리함
    /// </summary>
    /// <returns></returns>
    public abstract Collider[] ReturnColliders();
    
    
    private void Update()
    {
        cols = ReturnColliders();

        foreach (var col in cols)
        {
            if (CheckDic[col] != false)
                return;
            
            CheckDic[col] = true;
            CastAct?.Invoke(col);

        }
    }
}
