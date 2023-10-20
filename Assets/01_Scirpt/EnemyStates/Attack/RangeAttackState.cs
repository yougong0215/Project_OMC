using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine_Jang
{
    public class RangeAttackState : AttackState
    {
        private GameObject bullet;

        public RangeAttackState(Enemy enemy, GameObject bullet) : base(enemy)
        {
            this.bullet = bullet;
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