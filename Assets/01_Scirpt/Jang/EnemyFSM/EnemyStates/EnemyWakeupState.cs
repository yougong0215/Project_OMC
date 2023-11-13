using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWakeupState : CommonState
{
    public override void EnterState()
    {
        _animator.OnAnimationEventTrigger += EventAction;
        _animator.OnAnimationEndTrigger += EndAction;
        _animator.SetWakeAnimation(true);
    }

    public override void UpdateState()
    {
        UpdateAction?.Invoke();
    }

    public override void ExitState()
    {
        _animator.OnAnimationEventTrigger -= EventAction;
        _animator.OnAnimationEndTrigger -= EndAction;
        _animator.SetWakeAnimation(false);
    }
}
