using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : CommonState
{
    [SerializeField] private float moveDec;
    [SerializeField] private LayerMask obstacleMask;

    private Transform playerTrs;

    private void Start()
    {
        playerTrs = GameObject.FindWithTag("Player").transform;
    }

    public override void EnterState()
    {
        _animator.Animator.SetBool("Attack", true);
        EventAction?.Invoke();
    }

    public override void UpdateState()
    {
        Vector3 dir = playerTrs.position - transform.position;
        Ray ray = new Ray(transform.position, dir);
        RaycastHit playerHit;
        bool isPlayer = Physics.Raycast(ray, out playerHit, moveDec, LayerMask.GetMask("Player"));
        bool isObstacle = Physics.Raycast(ray, moveDec, obstacleMask);

        if (!isPlayer || isObstacle)
        {
            fsm.ChangeState(FSMState.Run);
        }

        UpdateAction?.Invoke();
    }

    public override void ExitState()
    {
        _animator.Animator.SetBool("Attack", false);
        EndAction?.Invoke();
    }
}
