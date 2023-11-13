using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrustaspikanAttackState : EnemyAttackState
{
    [Header("CrustaspikanOverride")]
    public CrustaspikanInfo info;
    public EnemyWeaponStance[] weaponStances;

    public override void EnterState()
    {
        base.EnterState();
        moveDec = info.NowMovedec();
    }

    public override void UpdateState()
    {
        Vector3 dir = playerTrs.position - transform.position;
        Ray ray = new Ray(transform.position, dir);
        RaycastHit playerHit;

        bool isPlayer = Physics.Raycast(ray, out playerHit, moveDec, LayerMask.GetMask("Player"));
        bool isObstacle = Physics.Raycast(ray, moveDec, obstacleMask);

        if ((!isPlayer || isObstacle) && !weaponStance.IsAttacking()) //범위에서 벗어나면
        {
            fsm.ChangeState(FSMState.Run);
        }

        UpdateAction?.Invoke();
    }

    public override void ExitState()
    {
        _animator.SetAttackAnimation(false);
        _animator.OnAnimationEventTrigger -= EventAction;
        _animator.OnAnimationEndTrigger -= EndAction;

        foreach (EnemyWeaponStance weaponStance in weaponStances)
            weaponStance.ExitAttack();
    }
}
