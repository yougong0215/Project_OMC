using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace StateMachine_Jang
{
    public class MoveState : BaseState
    {
        public MoveState(Enemy enemy) : base(enemy) { }

        public override void OnStateEnter()
        {
            enemy.navMeshAgent.isStopped = false;
            enemy.navMeshAgent.destination = enemy.player.transform.position;
            enemy.anim.SetBool("Move", true);
        }

        public override void OnStateUpdate()
        {

        }

        public override void OnStateExit()
        {
            enemy.navMeshAgent.isStopped = true;
            //enemy.navMeshAgent.destination = enemy.transform.position;
            enemy.anim.SetBool("Move", false);
        }
    }
}
