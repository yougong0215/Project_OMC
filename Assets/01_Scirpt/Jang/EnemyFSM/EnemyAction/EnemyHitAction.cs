using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitAction : CommonAction
{
    protected override void Init()
    {
        
    }

    protected override void OnEventFunc()
    {

    }

    protected override void OnEndFunc()
    {
        com.FSMMain.ChangeState(FSMState.Idle);
    }

    protected override void OnUpdateFunc()
    {
        
    }
}
