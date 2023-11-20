using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Skill/Enemy/Attack2")]
public class NormalAttack2S0 : EnemySkillSO
{
    protected override bool CritReturn()
    {
        return base.CritReturn();
    }

    public override float DamageReturn()
    {
        return base.DamageReturn();
    }

    public override void SKillInvoke(Collider cols, bool Damaged =true)
    {
        base.SKillInvoke(cols);
    }
}
