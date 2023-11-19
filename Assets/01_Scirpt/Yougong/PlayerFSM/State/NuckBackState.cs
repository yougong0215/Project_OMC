using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuckBackState : CommonState
{
    private void Start()
    {
        EndAction +=  ()=> fsm.ChangeState(FSMState.Idle);
    }

    public override void EnterState()
    {
        _animator.SetNuckDownAnimation(true);
        _animator.OnAnimationEventTrigger  += EventAction;
        _animator.OnAnimationEndTrigger += EndAction;
    }
    

    public override void UpdateState()
    {
        
    }
    

    public override void ExitState()
    {
        _animator.SetNuckDownAnimation(false);
        _animator.OnAnimationEventTrigger  -= EventAction;
        _animator.OnAnimationEndTrigger    -= EndAction;
    }
}
