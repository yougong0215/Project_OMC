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
        //throw new System.NotImplementedException();
    }

    public override void UpdateState()
    {
        //throw new System.NotImplementedException();
    }

    public override void ExitState()
    {
        //throw new System.NotImplementedException();
    }
}
