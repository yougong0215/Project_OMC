using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "SO/Skill/Enemy/Speed")]
public class SpeedAttackSO : EnemySkillSO
{
    public override void Init(CharacterInfo info, ObjectStat weapon, ColliderCast cols)
    {
        base.Init(info, weapon, cols);
        enemyInfo.DashInit();
    }

    protected override bool CritReturn()
    {
        return base.CritReturn();
    }

    public override float DamageReturn()
    {
        return base.DamageReturn();
    }

    public override void SKillInvoke(Collider cols)
    {
        base.SKillInvoke(cols);
    }
}
