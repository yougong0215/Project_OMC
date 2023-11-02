using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public enum AttackState
{
    NORMAL1,
    NORMAL2,
    NORMAL3,
    POWER,
    SPEED,
    THROW
};

public class EnemyMoveState : CommonState
{
    [SerializeField] private float idleDec;
    [SerializeField] private float attackDec;

    private NavMeshAgent agent;
    private Transform playerTrs;

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
        else if (playerHit.distance <= attackDec)
        {
            fsm.ChangeState(FSMState.Attack);
        }

        UpdateAction?.Invoke();
    }

    public override void ExitState()
    {
        Debug.Log(agent.isStopped);
        agent.isStopped = true;
        _animator.SetMoveAnimation(false);
    }
}
