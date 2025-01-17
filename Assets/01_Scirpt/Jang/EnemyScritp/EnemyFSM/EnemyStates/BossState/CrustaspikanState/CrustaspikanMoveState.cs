using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CrustaspikanMoveState : EnemyMoveState
{
    [Header("CrustaspikanOverride")]
    [SerializeField] protected CrustaspikanInfo info;
    [SerializeField] protected EnemyWeaponStance[] weaponStances;

    protected override void Start()
    {
        base.Start();
    }

    public override void EnterState()
    {
        base.EnterState();
        PattenSet();
    }

    private void PattenSet()
    {
        info.RandomPatten();
        attackEnum = info.NowAttackEnum();
        moveDec = info.NowMovedec();
    }

    public override void UpdateState()
    {
        Vector3 dir = (playerTrs.position + new Vector3(0, 1, 0) - transform.position).normalized;
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
