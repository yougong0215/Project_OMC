using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyMoveState : EnemyMoveState
{
    public override void UpdateState()
    {
        Vector3 dir = playerTrs.position - transform.position;
        Ray ray = new Ray(transform.position, dir);
        RaycastHit playerHit;
        bool isPlayer = Physics.Raycast(ray, out playerHit, idleDec, LayerMask.GetMask("Player"));

        if (!isPlayer)
        {
            fsm.ChangeState(FSMState.Idle);
        }
        else if (playerHit.distance <= moveDec)
        {
            NormalAttackPatten();
        }

        UpdateAction?.Invoke();
    }

    private void NormalAttackPatten()
    {
        int random = Random.Range(0, 3);
        Debug.Log(random);
        switch (random)
        {
            case 0:
                weaponStance.ChangeColliderCase(AttackEnum.NORMAL1);
                break;
            case 1:
                weaponStance.ChangeColliderCase(AttackEnum.NORMAL2);
                break;
            case 2:
                weaponStance.ChangeColliderCase(AttackEnum.NORMAL3);
                break;
        }
    }
}
