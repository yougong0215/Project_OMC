using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrustaspikanIdleState : EnemyIdleState
{
    [Header("CrustaspikanOverride")]
    [SerializeField] protected EnemyWeaponStance[] weaponStances;
    private bool isStart;

    protected override void Start()
    {
        playerTrs = GameObject.FindWithTag("Player").transform;

        foreach(EnemyWeaponStance weaponStance in weaponStances)
            weaponStance.AllAttack_Create();
    }

    public override void UpdateState()
    {
        Vector3 dir = (playerTrs.position + new Vector3(0, 1, 0) - transform.position).normalized;
        Ray ray = new Ray(transform.position, dir);
        RaycastHit playerHit;
        bool isPlayer = Physics.Raycast(ray, out playerHit, moveDec, LayerMask.GetMask("Player"));
        bool isObstacle = Physics.Raycast(ray, moveDec, obstacleMask);

        if (isPlayer && !isObstacle)
        {
            if (isStart)
                fsm.ChangeState(FSMState.Run);
            else
            {
                isStart = true;
                fsm.ChangeState(FSMState.WakeUP);
            }
        }

        UpdateAction?.Invoke();
    }
}
