using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrustaspikanAttackState : EnemyAttackState
{
    [Header("CrustaspikanOverride")]
    [SerializeField] protected EnemyWeaponStance[] weaponStances;

    public override void ExitState()
    {
        _animator.SetAttackAnimation(false);
        _animator.OnAnimationEventTrigger -= EventAction;
        _animator.OnAnimationEndTrigger -= EndAction;

        foreach (EnemyWeaponStance weaponStance in weaponStances)
            weaponStance.ExitAttack();
    }
}
