using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : CommonState
{
    public override void EnterState()
    {
        EventAction?.Invoke();
    }

    public override void ExitState()
    {
        UpdateAction?.Invoke();
    }

    public override void UpdateState()
    {
        EndAction?.Invoke();
    }
}
