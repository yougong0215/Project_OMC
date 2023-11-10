using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.IO.LowLevel.Unsafe;
using Unity.Profiling;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveState : CommonState
{
    [SerializeField] protected EnemyWeaponStance weaponStance;
    [SerializeField] protected AttackEnum attackEnum;
    [SerializeField] protected float idleDec;
    [SerializeField] protected float moveDec;

    protected NavMeshAgent agent;
    protected Transform playerTrs;

    protected virtual void Start()
    {
        agent = Character.GetComponent<NavMeshAgent>();
        playerTrs = GameObject.FindWithTag("Player").transform;
    }

    public override void EnterState()
    {
        agent.isStopped = false;
        _animator.SetMoveAnimation(true);
    }

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
            
            weaponStance.ChangeColliderCase(attackEnum);
        }

        UpdateAction?.Invoke();
    }

    public override void ExitState()
    {
        agent.isStopped = true;
        _animator.SetMoveAnimation(false);
    }
}
