using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine_Jang
{
    public class MeleeAttackState : AttackState
    {
        public MeleeAttackState(Enemy enemy) : base(enemy)
        {

        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
        }

        public override void OnStateUpdate()
        {
            base.OnStateUpdate();
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
        }
    }
}