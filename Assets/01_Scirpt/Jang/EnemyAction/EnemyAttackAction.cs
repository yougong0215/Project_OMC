using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAction : CommonAction
{
    private EnemyAttackState attackState;

    private void Start()
    {
        attackState = transform.parent.GetComponent<EnemyAttackState>();
    }

    protected override void Init()
    {

    }

    protected override void OnEventFunc()
    {
        attackState.isAttacking = true;
    }

    protected override void OnUpdateFunc()
    {

    }

    protected override void OnEndFunc()
    {
        attackState.isAttacking = false;
    }
}
