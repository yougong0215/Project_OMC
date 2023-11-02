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

    public void ChangeAttackStance(AttackEnum attackEnum)
    {
        if (attackState.isAttacking) return;

        colliderCast = weaponStance.ChangeColliderCase(attackEnum, colliderCast);
    }

    protected override void OnEndFunc()
    {
        weaponStance.SkillOff(colliderCast);
        attackState.isAttacking = false;

        RandomPatten();
    }

    private void RandomPatten()
    {
        int r = Random.Range(0, 3);
        switch (r) 
        {
            case 0:
                ChangeAttackStance(AttackEnum.NORMAL1);
                Debug.Log(0);
                break;
            case 1:
                ChangeAttackStance(AttackEnum.NORMAL2);
                Debug.Log(1);
                break;
            case 2:
                ChangeAttackStance(AttackEnum.NORMAL3);
                Debug.Log(2);
                break;
        }
    }
}
