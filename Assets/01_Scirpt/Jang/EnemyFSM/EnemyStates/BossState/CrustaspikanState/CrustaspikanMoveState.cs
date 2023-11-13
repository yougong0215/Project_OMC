using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrustaspikanMoveState : EnemyMoveState
{
    [Header("CrustaspikanOverride")]
    [SerializeField] protected EnemyWeaponStance[] weaponStances;

    public override void UpdateState()
    {
        Vector3 dir = playerTrs.position - transform.position;
        Ray ray = new Ray(transform.position, dir.normalized);
        RaycastHit playerHit;
        bool isPlayer = Physics.Raycast(ray, out playerHit, idleDec, LayerMask.GetMask("Player"));

        if (!isPlayer)
        {
            fsm.ChangeState(FSMState.Idle);
        }
        else if (playerHit.distance <= moveDec)
        {
            foreach (EnemyWeaponStance weaponStance in weaponStances)
                weaponStance.ChangeColliderCase(attackEnum);
        }

        UpdateAction?.Invoke();
    }
}
