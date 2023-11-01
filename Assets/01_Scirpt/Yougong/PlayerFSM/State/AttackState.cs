using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : CommonState
{

    public override void EnterState()
    {
        Init?.Invoke();
        
        _animator.SetAttackAnimation(true);
        
        _animator.OnAnimationEventTrigger  += EventAction;
        _animator.OnAnimationEndTrigger    += EndAction;
    }

    public override void UpdateState()
    {
        UpdateAction?.Invoke();
        //throw new System.NotImplementedException();
    }

    public override void ExitState()
    {
        _animator.SetAttackAnimation(false);
       // throw new System.NotImplementedException();
       _animator.OnAnimationEventTrigger  -= EventAction;
       _animator.OnAnimationEndTrigger    -= EndAction;
    }
}
