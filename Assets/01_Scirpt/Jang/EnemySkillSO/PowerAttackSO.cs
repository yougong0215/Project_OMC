using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Skill/Enemy/Power")]
public class PowerAttackSO : EnemySkillSO
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
