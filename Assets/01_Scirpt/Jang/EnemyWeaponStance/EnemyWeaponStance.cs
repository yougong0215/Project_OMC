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
    [SerializeField] private EnemyInfo enemyInfo;

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
        enemyInfo.isAttack = value;
    }

    public bool IsAttacking()
    {
        return allColliderCast[currentAttackEnum].IsAttack;
    }

    public void ChangeColliderCase(AttackEnum attackEnum)
    {
        if (IsAttacking())//현재 실행중인얘가 공격 다 안끝남
            return;//근데 어차피 idle이나 run일때 해주니까 없도도 되지 않나...?

        currentAttackEnum = attackEnum;//상태 바꾸고
        allColliderCast[currentAttackEnum].Init(enemyInfo, weaponSO.statSo);//액션 넣어줘야지
        allColliderCast[currentAttackEnum].transform.SetParent(transform);//플레이어는 왜 콜라이더 부모를 없엤는지 모르겠지만 유지해야됨
        allColliderCast[currentAttackEnum].Attack(true);
    }

    public void ExitAttack()
    {
        allColliderCast[currentAttackEnum].CastAct = null; //얘 안지우면 전 공격도 피격처리 되겠지
        allColliderCast[currentAttackEnum].CheckDic = new(); //맞았던 기록 엎에고
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
