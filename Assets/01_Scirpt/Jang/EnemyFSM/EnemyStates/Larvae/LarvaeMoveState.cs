using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LarvaeMoveState : EnemyMoveState
{
    [SerializeField] private float dashDec;

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
            weaponStance.ChangeColliderCase(AttackEnum.NORMAL1);
        }
        else if (playerHit.distance <= dashDec && playerHit.distance > dashDec - 0.5f)
        {
            weaponStance.ChangeColliderCase(AttackEnum.SPEED);
        }

        UpdateAction?.Invoke();
    }
}
