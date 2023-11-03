using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Skill/Enemy/Speed")]
public class SpeedAttackSO : EnemySkillSO
{
    [SerializeField] private float moveDirction;

    public override void Init(CharacterInfo info, ObjectStat weapon, ColliderCast cols)
    {
        base.Init(info, weapon, cols);
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

    public void Dash()
    {
        Debug.Log("´ë½¬");
    }
}
