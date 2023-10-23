using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : CommonState
{
    [SerializeField] private float moveDec;

    public override void EnterState()
    {
        _animator.Animator.SetBool("Idle", true);
        EventAction?.Invoke();
    }

    public override void UpdateState()
    {
        bool isPlayer = Physics.OverlapSphere(transform.position, moveDec,
                                             LayerMask.GetMask("Player")).Length > 0;
        if (isPlayer)
        {
            fsm.ChangeState(FSMState.Run);
        }

        UpdateAction?.Invoke();
    }

    public override void ExitState()
    {
        _animator.Animator.SetBool("Idle", false);
        EndAction?.Invoke();
    }
}
