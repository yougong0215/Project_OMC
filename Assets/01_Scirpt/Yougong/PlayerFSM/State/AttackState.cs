using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : CommonState
{

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
       // throw new System.NotImplementedException();
    }
}
