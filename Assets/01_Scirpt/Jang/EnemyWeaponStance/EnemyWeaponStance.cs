using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponStance : MonoBehaviour
{
    /// <summary>
    /// �Ϲݰ���1
    /// </summary>
    public Action Normal_Attack_1 = null;

    /// <summary>
    /// �Ϲݰ���2
    /// </summary>
    public Action Normal_Attack_2 = null;

    /// <summary>
    /// �Ϲݰ���3
    /// </summary>
    public Action Normal_Attack_3 = null;

    /// <summary>
    /// ������ ����
    /// </summary>
    public Action Power_Attack = null;

    /// <summary>
    /// ��������, ��������
    /// </summary>
    public Action Speed_Attack = null;

    /// <summary>
    /// �߻�ü ����
    /// </summary>
    public Action Throw_Attack = null;

    [SerializeField] private EnemyWeaponSO weaponSO;
    [SerializeField] private CharacterInfo enemy;

    public ColliderCast NormalAttack1_Create()
    {
        ColliderCast obj = Instantiate(weaponSO.Normal_Attack_1, transform);
        return obj;
    }

    public ColliderCast NormalAttack2_Create()
    {
        ColliderCast obj = Instantiate(weaponSO.Normal_Attack_2, transform);
        return obj;
    }

    public ColliderCast NormalAttack3_Create()
    {
        ColliderCast obj = Instantiate(weaponSO.Normal_Attack_3, transform);
        return obj;
    }

    public ColliderCast PowerAttack_Create()
    {
        ColliderCast obj = Instantiate(weaponSO.Power_Attack, transform);
        return obj;
    }

    public ColliderCast SpeedAttack_Create()
    {
        ColliderCast obj = Instantiate(weaponSO.Speed_Attack, transform);
        return obj;
    }

    public ColliderCast ThrowAttack_Create()
    {
        ColliderCast obj = Instantiate(weaponSO.Throw_Attack, transform);
        return obj;
    }

    public void SkillOn(ColliderCast obj)
    {
        obj.Init(enemy, weaponSO.Stat);
        obj.Attack(true);
    }

    public void SkillOff(ColliderCast obj)
    {
        obj.CastAct = null;
        obj.Attack(false);
    }
}
