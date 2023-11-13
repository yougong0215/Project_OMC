using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrustaspikanAttackAction : EnemyAttackAction
{
    [Header("CrustaspikanOverride")]
    protected CrustaspikanInfo info;
    protected EnemyWeaponStance[] weaponStances;

    protected override void Init()
    {
        base.Init();
        info = com.GetComponent<CrustaspikanAttackState>().info;
        weaponStances = com.GetComponent<CrustaspikanAttackState>().weaponStances;
    }

    protected override void OnEventFunc()
    {
        foreach (EnemyWeaponStance weaponStance in weaponStances)
            weaponStance.NowColliderCase().CheckDic = new();

        weaponStance.Attack(true);
    }

    protected override void OnEndFunc()
    {
        base.OnEndFunc();
    }
}
