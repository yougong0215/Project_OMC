using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine_Jang
{
    public class FSM
    {
        public FSM(BaseState initState)
        {
            currentState = initState;
            currentState.OnStateEnter();
        }

        private BaseState currentState;

        public void ChangeState(BaseState newState)
        {
            if (newState == currentState) return;

            if (newState != null)
                currentState.OnStateExit();

            currentState = newState;
            currentState.OnStateEnter();
        }

        public void UpdateState()
        {
            if (currentState != null)
                currentState.OnStateUpdate();
        }
    }
}
