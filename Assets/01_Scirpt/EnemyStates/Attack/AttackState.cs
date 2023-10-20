using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine_Jang
{
    public class AttackState : BaseState
    {
        public bool isAttacking;

        public AttackState(Enemy enemy) : base(enemy) { }

        public override void OnStateEnter()
        {
            enemy.anim.SetBool("Attack", true);
        }

        public override void OnStateUpdate()
        {

        }

        public override void OnStateExit()
        {
            isAttacking = false;
            enemy.anim.SetBool("Attack", false);
        }

        public void OnAttack()
        {
            Debug.Log("ÄÆ");
        }
    }
}
