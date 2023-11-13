using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrustaspikanInfo : EnemyInfo
{
    [SerializeField] private float arousalHp;
    [HideInInspector] public bool isArousal;

    public override void GetDamage(float _damage, bool _nuckBack = false)
    {
        enemyHp -= _damage;

        if (enemyHp <= 0)
            FSM.ChangeState(FSMState.Die);
        else if (enemyHp < arousalHp && !isArousal)
        {
            isArousal = true;
            FSM.ChangeState(FSMState.WakeUP);
        }
    }
}
