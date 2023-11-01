using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAction : CommonAction
{
    private EnemyAttackState attackState;

    private EnemyWeaponStance weaponStance;
    private ColliderCast colliderCast;

    private void Start()
    {
        attackState = transform.parent.GetComponent<EnemyAttackState>();
    }

    protected override void Init()
    {
        weaponStance = attackState.weaponStance;
        colliderCast = attackState.colliderCast;
    }

    protected override void OnEventFunc()
    {
        weaponStance.SkillOn(colliderCast);
        attackState.isAttacking = true;
    }

    protected override void OnUpdateFunc()
    {

    }

    protected override void OnEndFunc()
    {
        weaponStance.SkillOff(colliderCast);
        attackState.isAttacking = false;
    }
}
