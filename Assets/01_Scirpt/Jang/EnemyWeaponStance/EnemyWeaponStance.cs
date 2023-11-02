using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackEnum
{
    NORMAL1 = 0,
    NORMAL2 = 1,
    NORMAL3 = 2,
    POWER = 3,
    SPEED = 4,
    THROW = 5
};

public class EnemyWeaponStance : MonoBehaviour
{
    private Dictionary<AttackEnum, ColliderCast> allColliderCast = new Dictionary<AttackEnum, ColliderCast>();

    [SerializeField] private EnemyWeaponSO weaponSO;
    [SerializeField] private CharacterInfo enemy;

    public ColliderCast ChangeColliderCase(AttackEnum attackEnum, ColliderCast orgColliderCast)
    {
        //if(orgColliderCast != allColliderCast[attackEnum])
        //    allColliderCast[attackEnum].Init(enemy, weaponSO.Stat);
        
        return allColliderCast[attackEnum];
    }

    public void NormalAttack1_Create()
    {
        ColliderCast nomal1Obj = Instantiate(weaponSO.Normal_Attack_1, transform);
        allColliderCast[AttackEnum.NORMAL1] = nomal1Obj;
    }

    public void NormalAttack2_Create()
    {
        ColliderCast nomal2Obj = Instantiate(weaponSO.Normal_Attack_2, transform);
        allColliderCast[AttackEnum.NORMAL2] = nomal2Obj;
    }

    public void NormalAttack3_Create()
    {
        ColliderCast nomal3Obj = Instantiate(weaponSO.Normal_Attack_3, transform);
        allColliderCast[AttackEnum.NORMAL3] = nomal3Obj;
    }

    public void PowerAttack_Create()
    {
        ColliderCast powerObj = Instantiate(weaponSO.Power_Attack, transform);
        allColliderCast[AttackEnum.POWER] = powerObj;
    }

    public void SpeedAttack_Create()
    {
        ColliderCast speedObj = Instantiate(weaponSO.Speed_Attack, transform);
        allColliderCast[AttackEnum.SPEED] = speedObj;
    }

    public void ThrowAttack_Create()
    {
        ColliderCast throwObj = Instantiate(weaponSO.Throw_Attack, transform);
        allColliderCast[AttackEnum.THROW] = throwObj;
    }

    public void AllAttack_Create()
    {
        ColliderCast nomal1Obj = Instantiate(weaponSO.Normal_Attack_1, transform);
        allColliderCast[AttackEnum.NORMAL1] = nomal1Obj;
        ColliderCast nomal2Obj = Instantiate(weaponSO.Normal_Attack_2, transform);
        allColliderCast[AttackEnum.NORMAL2] = nomal2Obj;
        ColliderCast nomal3Obj = Instantiate(weaponSO.Normal_Attack_3, transform);
        allColliderCast[AttackEnum.NORMAL3] = nomal3Obj;
        ColliderCast powerObj = Instantiate(weaponSO.Power_Attack, transform);
        allColliderCast[AttackEnum.POWER] = powerObj;
        ColliderCast speedObj = Instantiate(weaponSO.Speed_Attack, transform);
        allColliderCast[AttackEnum.SPEED] = speedObj;
        ColliderCast throwObj = Instantiate(weaponSO.Throw_Attack, transform);
        allColliderCast[AttackEnum.THROW] = throwObj;
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
