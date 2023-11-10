using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LarvaeAttactState : EnemyAttackState
{
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
        else if (!weaponStance.IsAttacking() && weaponStance.currentAttackEnum == AttackEnum.SPEED)
        {
            Debug.Log("일공");
            weaponStance.ChangeColliderCase(AttackEnum.NORMAL1);
        }

        UpdateAction?.Invoke();
    }
}
