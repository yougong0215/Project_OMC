using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxReturnHome : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out PlayerInfo _pl))
        {
            _pl.FSM.ChangeState(FSMState.Die);
        }
    }
}
