using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Skill/Enemy")]
public class EnemySkillSO : SkillSO
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
