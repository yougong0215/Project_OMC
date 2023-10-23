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
        Init?.Invoke();
        //throw new System.NotImplementedException();
        
    }

    public override void UpdateState()
    {
        UpdateAction?.Invoke();
        //throw new System.NotImplementedException();
    }

    public override void ExitState()
    {
        EndAction?.Invoke();
        
        //throw new System.NotImplementedException();
    }
}
