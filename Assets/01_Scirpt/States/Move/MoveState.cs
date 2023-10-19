using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine_Jang
{
    public class MoveState : BaseState
    {
        public MoveState(Enemy enemy) : base(enemy) { }

        public override void OnStateEnter()
        {
            enemy.anim.SetBool("Move", true);
        }

        public override void OnStateUpdate()
        {

        }

        public override void OnStateExit()
        {
            enemy.anim.SetBool("Move", false);
        }
    }
}
