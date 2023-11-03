using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAction : CommonAction
{
    private EnemyWeaponStance weaponStance;

    protected override void Init()
    {
        weaponStance = com.GetComponent<EnemyAttackState>().weaponStance;
    }

    protected override void OnEventFunc()
    {
        weaponStance.NowColliderCase().CheckDic = new();
        weaponStance.Attack(true);
    }

    protected override void OnUpdateFunc()
    {

    }

    protected override void OnEndFunc()
    {
        weaponStance.Attack(false);
    }
}
