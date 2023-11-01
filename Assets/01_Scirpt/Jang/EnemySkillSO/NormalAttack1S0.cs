using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Skill/Enemy/Attack1")]
public class NormalAttack1S0 : EnemySkillSO
{
    public override float DamageReturn()
    {
        return base.DamageReturn();
    }

    public override void SKillInvoke(Collider cols)
    {
        base.SKillInvoke(cols);
    }
}
