using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum AttackEnum
{
    NORMAL1 = 0,
    NORMAL2 = 1,
    NORMAL3 = 2,
    POWER = 3,
    SPEED = 4,
    THROW = 5,
    NONE = 6
};

public class EnemyWeaponStance : MonoBehaviour
{
    public AttackEnum currentAttackEnum { get; private set; }

    private Dictionary<AttackEnum, ColliderCast> allColliderCast = new Dictionary<AttackEnum, ColliderCast>();

    [SerializeField] private EnemyWeaponSO weaponSO;
    [SerializeField] private CharacterInfo enemy;

    //public AttackEnum NowColliderCastEnum(ColliderCast nowColliderCast)
    //{
    //    foreach (AttackEnum attackEnum in allColliderCast.Keys)
    //    {
    //        if (nowColliderCast == allColliderCast[attackEnum])
    //        {
    //            Debug.Log(attackEnum);
    //            return attackEnum;
    //        }
    //    }
    //    Debug.LogError("nowColliderCast is not exist allColliderCast");
    //    return AttackEnum.NONE;
    //}

    public ColliderCast NowColliderCase()
    {
        return allColliderCast[currentAttackEnum];
    }

    public void Attack(bool value)
    {
        allColliderCast[currentAttackEnum].Attack(value);
    }

    public bool IsAttacking()
    {
        return allColliderCast[currentAttackEnum].IsAttack;
    }

    public void ChangeColliderCase(AttackEnum attackEnum)
    {
        if (IsAttacking())//���� �������ξ갡 ���� �� �ȳ���
            return;//�ٵ� ������ idle�̳� run�϶� ���ִϱ� ������ ���� �ʳ�...?

        currentAttackEnum = attackEnum;//���� �ٲٰ�
        allColliderCast[currentAttackEnum].Init(enemy, weaponSO.Stat);//�׼� �־������
        allColliderCast[currentAttackEnum].transform.SetParent(transform);//�÷��̾�� �� �ݶ��̴� �θ� ���x���� �𸣰����� �����ؾߵ�
        allColliderCast[currentAttackEnum].Attack(true);
    }

    public void ExitAttack()
    {
        allColliderCast[currentAttackEnum].CastAct = null; //�� ������� �� ���ݵ� �ǰ�ó�� �ǰ���
        allColliderCast[currentAttackEnum].CheckDic = new(); //�¾Ҵ� ��� ������
    }

    private void Attack_Create(ColliderCast colliderCast, AttackEnum attackEnum)
    {
        if (colliderCast == null)
            return;
        ColliderCast nomal2Obj = Instantiate(colliderCast, transform);
        allColliderCast[attackEnum] = nomal2Obj;
    }

    public void AllAttack_Create()
    {
        ColliderCast[] casts = {
            weaponSO.Normal_Attack_1 ,
            weaponSO.Normal_Attack_2,
            weaponSO.Normal_Attack_3,
            weaponSO.Power_Attack,
            weaponSO.Speed_Attack,
            weaponSO.Throw_Attack
        };

        AttackEnum[] enums = {
            AttackEnum.NORMAL1,
            AttackEnum.NORMAL2,
            AttackEnum.NORMAL3,
            AttackEnum.POWER,
            AttackEnum.SPEED,
            AttackEnum.THROW
        };

        for (int i = 0; i < casts.Length; i++)
            Attack_Create(casts[i], enums[i]);
    }
}
