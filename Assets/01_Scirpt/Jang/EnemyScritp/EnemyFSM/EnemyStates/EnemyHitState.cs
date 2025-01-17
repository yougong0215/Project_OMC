using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

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
        UpdateAction?.Invoke();
    }

    public override void ExitState()
    {
        _animator.SetHitAnimation(false);
        _animator.OnAnimationEventTrigger -= EventAction;
        _animator.OnAnimationEndTrigger -= EndAction;
    }
}
