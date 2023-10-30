using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine_Jang
{
    public abstract class BaseState
    {
        protected Enemy enemy;

        protected BaseState(Enemy enemy)
        {
            this.enemy = enemy;
        }

        public abstract void OnStateEnter();
        public abstract void OnStateUpdate();
        public abstract void OnStateExit();
    }
}