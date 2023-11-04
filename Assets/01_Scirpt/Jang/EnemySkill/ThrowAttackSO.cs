using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Skill/Enemy/Throw")]
public class ThrowAttackSO : EnemySkillSO
{
    [SerializeField] private FirePrefab firePrefab;

    private Transform playerTrs;

    public override void Init(CharacterInfo info, ObjectStat weapon, ColliderCast cols)
    {
        base.Init(info, weapon, cols);

        playerTrs = GameObject.FindWithTag("Player").transform;
        enemyInfo.skillStartEvt += FireAttack;
    }

    protected override bool CritReturn()
    {
        return base.CritReturn();
    }

    public override float DamageReturn()
    {
        return base.DamageReturn();
    }

    private void FireAttack()
    {
        FirePrefab fireObj = Instantiate(firePrefab, colliderCast.transform.position, Quaternion.identity);
        fireObj.FireSetting(playerTrs.position, DamageReturn());
    }
}
