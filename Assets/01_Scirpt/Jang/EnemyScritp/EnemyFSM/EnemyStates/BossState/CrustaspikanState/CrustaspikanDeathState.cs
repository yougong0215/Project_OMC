using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrustaspikanDeathState : EnemyDeathState
{
    [SerializeField] private CrustaspikanInfo bossInfo;
    [SerializeField] private GameObject bossUI;

    public override void EnterState()
    {
        base.EnterState();
        bossUI.SetActive(false);
    }

    public override void ExitState()
    {
        bossInfo.BossDeath();
    }
}
