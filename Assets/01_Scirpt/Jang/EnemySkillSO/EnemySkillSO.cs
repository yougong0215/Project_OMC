using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "SO/Skill/Enemy")]
public class EnemySkillSO : SkillSO
{
    protected EnemyInfo enemyInfo;

    public override void Init(CharacterInfo info, ObjectStat weapon, ColliderCast cols)
    {
        base.Init(info, weapon, cols);
        enemyInfo = _info.GetComponent<EnemyInfo>();
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
