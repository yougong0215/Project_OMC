using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMoveState : CommonState
{
    [SerializeField] private float idleDec;
    [SerializeField] private float attackDec;

    private Transform playerTrs;

    private void Start()
    {
        playerTrs = GameObject.FindWithTag("Player").transform;
    }

    public override void EnterState()
    {
        _animator.Animator.SetBool("Move", true);
        EventAction?.Invoke();
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
        _animator.Animator.SetBool("Move", false);
        EndAction?.Invoke();
    }
}
