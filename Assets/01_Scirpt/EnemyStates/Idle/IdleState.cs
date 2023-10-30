using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine_Jang
{
    public class IdleState : BaseState
    {
        public IdleState(Enemy enemy) : base(enemy) { }

        public override void OnStateEnter()
        {
            enemy.anim.SetBool("Idle", true);
        }

        public override void OnStateUpdate()
        {

        }

        public override void OnStateExit()
        {
            enemy.anim.SetBool("Idle", false);
        }
    }
}
