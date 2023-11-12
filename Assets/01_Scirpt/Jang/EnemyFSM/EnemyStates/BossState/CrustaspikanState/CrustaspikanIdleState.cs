using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrustaspikanIdleState : EnemyIdleState
{
    [Header("CrustaspikanOverride")]
    [SerializeField] protected EnemyWeaponStance[] weaponStances;

    protected override void Start()
    {
        playerTrs = GameObject.FindWithTag("Player").transform;

        foreach(EnemyWeaponStance weaponStance in weaponStances)
            weaponStance.AllAttack_Create();
    }
}
