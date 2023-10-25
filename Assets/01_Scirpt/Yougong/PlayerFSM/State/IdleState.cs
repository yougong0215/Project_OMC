using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : CommonState
{
    public void Start()
    {
        fsm.ChangeState(FSMState.Idle);
        /// fsm.Player.position
        
    }
    public override void EnterState()
    {
        _animator.OnAnimationEventTrigger  += EventAction;
        _animator.OnAnimationEndTrigger    += EndAction;
    }

    public override void UpdateState()
    {
        UpdateAction?.Invoke();
        
    }

    public override void ExitState()
    {
        _animator.OnAnimationEventTrigger  -= EventAction;
        _animator.OnAnimationEndTrigger    -= EndAction;
    }
}
