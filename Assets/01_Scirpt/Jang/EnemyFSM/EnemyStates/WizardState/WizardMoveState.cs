using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardMoveState : EnemyMoveState
{
    public override void UpdateState()
    {
        Vector3 dir = playerTrs.position - transform.position;
        Ray ray = new Ray(transform.position, dir);
        RaycastHit playerHit;
        bool isPlayer = Physics.Raycast(ray, out playerHit, idleDec, LayerMask.GetMask("Player"));

        if (!isPlayer)
        {
            fsm.ChangeState(FSMState.Idle);
        }
        else if (playerHit.distance <= moveDec)
        {
            weaponStance.ChangeColliderCase(AttackEnum.THROW);
        }

        UpdateAction?.Invoke();
    }
}
