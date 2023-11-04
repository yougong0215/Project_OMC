using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathState : CommonState
{
    public override void EnterState()
    {
        _animator.SetDeathAnimation(true);
        _animator.OnAnimationEventTrigger += EventAction;
        _animator.OnAnimationEndTrigger += EndAction;
    }

    public override void ExitState()
    {
        
    }

    public override void UpdateState()
    {
        _animator.SetDeathAnimation(false);
        _animator.OnAnimationEventTrigger -= EventAction;
        _animator.OnAnimationEndTrigger -= EndAction;
    }
}
