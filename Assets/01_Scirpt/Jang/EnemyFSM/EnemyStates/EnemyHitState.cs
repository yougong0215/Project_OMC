using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitState : CommonState
{
    public override void EnterState()
    {
        _animator.SetHitAnimation(true);
        _animator.OnAnimationEventTrigger += EventAction;
        _animator.OnAnimationEndTrigger += EndAction;
    }

    public override void UpdateState()
    {

    }

    public override void ExitState()
    {
        _animator.SetHitAnimation(false);
        _animator.OnAnimationEventTrigger -= EventAction;
        _animator.OnAnimationEndTrigger -= EndAction;
    }
}
