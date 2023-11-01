using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponStance : MonoBehaviour
{
    /// <summary>
    /// 일반공격1
    /// </summary>
    public Action Normal_Attack_1 = null;

    /// <summary>
    /// 일반공격2
    /// </summary>
    public Action Normal_Attack_2 = null;

    /// <summary>
    /// 일반공격3
    /// </summary>
    public Action Normal_Attack_3 = null;

    /// <summary>
    /// 강력한 공격
    /// </summary>
    public Action Power_Attack = null;

    /// <summary>
    /// 빠른공격, 돌진공격
    /// </summary>
    public Action Speed_Attack = null;

    /// <summary>
    /// 발사체 공격
    /// </summary>
    public Action Throw_Attack = null;

    [SerializeField] private EnemyWeaponSO weaponSO;
    [SerializeField] private CharacterInfo enemy;

    public void SkillOn()
    {
        SkillOff();

        Normal_Attack_1 += () =>
        {
            ColliderCast obj = Instantiate(weaponSO.Normal_Attack_1, transform);
            obj.Init(enemy, weaponSO.Stat);
        };

        Normal_Attack_2 += () =>
        {
            ColliderCast obj = Instantiate(weaponSO.Normal_Attack_2, transform);
            obj.Init(enemy, weaponSO.Stat);
        };

        Normal_Attack_3 += () =>
        {
            ColliderCast obj = Instantiate(weaponSO.Normal_Attack_3, transform);
            obj.Init(enemy, weaponSO.Stat);
        };

        Power_Attack += () =>
        {
            ColliderCast obj = Instantiate(weaponSO.Power_Attack, transform);
            obj.Init(enemy, weaponSO.Stat);
        };

        Speed_Attack += () =>
        {
            ColliderCast obj = Instantiate(weaponSO.Speed_Attack, transform);
            obj.Init(enemy, weaponSO.Stat);
        };

        Throw_Attack += () =>
        {
            ColliderCast obj = Instantiate(weaponSO.Throw_Attack, transform);
            obj.Init(enemy, weaponSO.Stat);
        };
    }

    public void SkillOff()
    {
        Normal_Attack_1 = null;
        Normal_Attack_2 = null;
        Normal_Attack_3 = null;
        Power_Attack = null;
        Speed_Attack = null;
    }
}
