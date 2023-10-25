using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : CommonState
{

    public override void EnterState()
    {
        _animator.SetMoveAnimation(true);
        _animator.OnAnimationEventTrigger  += EventAction;
        _animator.OnAnimationEndTrigger    += EndAction;
    }

    public override void UpdateState()
    {
        UpdateAction?.Invoke();
        
    }

    public override void ExitState()
    {
        _animator.SetMoveAnimation(false);
        _animator.OnAnimationEventTrigger  -= EventAction;
        _animator.OnAnimationEndTrigger    -= EndAction;
    }
}
