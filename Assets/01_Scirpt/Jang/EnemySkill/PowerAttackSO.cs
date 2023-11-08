using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Skill/Enemy/Power")]
public class PowerAttackSO : EnemySkillSO
{
    [SerializeField] private float increaseAtk;
    [SerializeField] private float increaseCrit;
    [SerializeField] private float increaseCritAmp;

    protected override bool CritReturn()
    {
        return Random.Range(0f, 100f) < _info.StatSo.Crit + WeaponStatSo.Crit + increaseCrit ? true : false;
    }

    public override float DamageReturn()
    {
        float increaseDmg = CritReturn() == true ? increaseCritAmp + increaseAtk : increaseAtk;
        return base.DamageReturn() * increaseDmg;
    }

    public override void SKillInvoke(Collider cols, bool Damaged =true)
    {
        base.SKillInvoke(cols);
    }
}
