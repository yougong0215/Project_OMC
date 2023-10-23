using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : CommonState
{
    public override void EnterState()
    {
        _animator.Animator.SetBool("Attack", true);
        EventAction?.Invoke();
    }

    public override void UpdateState()
    {
        UpdateAction?.Invoke();
    }

    public override void ExitState()
    {
        _animator.Animator.SetBool("Attack", false);
        EndAction?.Invoke();
    }
}
