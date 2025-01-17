using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : CommonState
{
    [SerializeField] protected EnemyWeaponStance weaponStance;
    [SerializeField] protected float moveDec;
    [SerializeField] protected LayerMask obstacleMask;

    protected Transform playerTrs;

    protected virtual void Start()
    {
        playerTrs = GameObject.FindWithTag("Player").transform;

        weaponStance.AllAttack_Create();
    }

    public override void EnterState()
    {
        
    }

    public override void UpdateState()
    {
        Vector3 dir = (playerTrs.position+ new Vector3(0,1,0) - transform.position).normalized;
        Ray ray = new Ray(transform.position, dir);
        RaycastHit playerHit;
        bool isPlayer = Physics.Raycast(ray, out playerHit, moveDec, LayerMask.GetMask("Player"));
        bool isObstacle = Physics.Raycast(ray, moveDec, obstacleMask);

        if (isPlayer && !isObstacle)
        {
            fsm.ChangeState(FSMState.Run);
        }

        UpdateAction?.Invoke();
    }

    public override void ExitState()
    {
        
    }
}
