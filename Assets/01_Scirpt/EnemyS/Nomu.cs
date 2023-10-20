using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using StateMachine_Jang;

public class Nomu : Enemy
{
    [Header("Value")]
    [SerializeField] private float rangeRadius;
    [SerializeField] private float attackRadius;

    [Header("Layer")]
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private LayerMask obstacleMask;

    protected override void Awake()
    {
        base.Awake();
        attackState = new StateMachine_Jang.MeleeAttackState(this);
    }

    protected override void IdleNode()
    {
        if (CanSeePlayer())
        {
            if (CanAttackPlayer())
            {
                ChangeState(State.Attack);
            }
            else
            {
                ChangeState(State.Move);
            }
        }
    }

    protected override void MoveNode()
    {
        if (CanSeePlayer())
        {
            if (CanAttackPlayer())
            {
                ChangeState(State.Attack);
            }
        }
        else
        {
            ChangeState(State.Idle);
        }
    }

    protected override void AttackNode()
    {
        if (attackState.isAttacking) return;

        if (CanSeePlayer())
        {
            if (!CanAttackPlayer())
            {
                ChangeState(State.Move);
            }
        }
        else
        {
            ChangeState(State.Idle);
        }
    }

    private bool CanSeePlayer()
    {
        Vector3 dir = player.transform.position - transform.position;
        Ray ray = new Ray(transform.position, dir);

        bool isPlayer = Physics.Raycast(ray, rangeRadius, playerMask);
        bool isObstacle = Physics.Raycast(ray, rangeRadius, obstacleMask);

        return isPlayer && !isObstacle;
    }

    private bool CanAttackPlayer() 
    {
        bool isPlayer = Physics.OverlapSphere(transform.position, attackRadius,
            LayerMask.GetMask("Player")).Length > 0;
        return isPlayer;
    }


#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangeRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
#endif
}
