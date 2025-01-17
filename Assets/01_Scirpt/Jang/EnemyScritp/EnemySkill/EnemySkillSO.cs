using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "SO/Skill/Enemy")]
public class EnemySkillSO : SkillSO
{
    protected EnemyInfo enemyInfo;
    protected ColliderCast colliderCast { get; private set; }

    public override void Init(CharacterInfo info, ObjectStatSO weapon, ColliderCast cols)
    {
        cols.CastAct = null;

        base.Init(info, weapon, cols);
        colliderCast = cols;
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

    public override void SKillInvoke(Collider cols, bool Damaged =true)
    {
        base.SKillInvoke(cols);
    }
}
