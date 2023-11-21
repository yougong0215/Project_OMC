using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : CommonState
{
    public override void EnterState()
    {
        _animator.SetDeathAnimation(true);
        UIManager.Instance.PanelGameOver();
    }

    public override void UpdateState()
    {
    }

    public override void ExitState()
    {
    }
}
