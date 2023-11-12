using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrustaspikanAttackAction : EnemyAttackAction
{
    [Header("CrustaspikanOverride")]
    [SerializeField] protected EnemyWeaponStance[] weaponStances;

    protected override void OnEventFunc()
    {
        foreach (EnemyWeaponStance weaponStance in weaponStances)
            weaponStance.NowColliderCase().CheckDic = new();

        weaponStance.Attack(true);
    }
}
