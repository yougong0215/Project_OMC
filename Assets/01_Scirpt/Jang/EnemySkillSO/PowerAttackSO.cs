using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Skill/Enemy/Power")]
public class PowerAttackSO : EnemySkillSO
{
    [SerializeField] private float increaseCrit;
    [SerializeField] private float increaseCritAmp;

    protected override bool CritReturn()
    {
        return Random.Range(0f, 100f) < _info.Stat.Crit + _weaponStat.Crit + increaseCrit ? true : false;
    }

    public override float DamageReturn()
    {
        return base.DamageReturn() * increaseCritAmp;
    }

    public override void SKillInvoke(Collider cols)
    {
        base.SKillInvoke(cols);
    }
}
