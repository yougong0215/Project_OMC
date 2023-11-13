using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CrustaspikanInfo : EnemyInfo
{
    [SerializeField] private float arousalHp;
    [Header("공격범위")]
    [SerializeField] protected float nor1Dec, nor2Dec, nor3Dec, powDec, sedDec, thrDec;
    [HideInInspector] public bool isArousal;

    private List<Tuple<AttackEnum, float>> pattens = new List<Tuple<AttackEnum, float>>();
    private Tuple<AttackEnum, float> currentPatten;

    protected override void Start()
    {
        base.Start();

        pattens.Add(new Tuple<AttackEnum, float>(AttackEnum.NORMAL1, nor1Dec));
        pattens.Add(new Tuple<AttackEnum, float>(AttackEnum.NORMAL2, nor2Dec));
        pattens.Add(new Tuple<AttackEnum, float>(AttackEnum.NORMAL3, nor3Dec));
    }

    public void RandomPatten()
    {
        int idx = UnityEngine.Random.Range(0, 3);
        currentPatten = pattens[idx];
    }

    public AttackEnum NowAttackEnum()
    {
        return currentPatten.Item1;
    }

    public float NowMovedec()
    {
        return currentPatten.Item2;
    }

    public override void GetDamage(float _damage)
    {
        enemyHp -= _damage;

        if (enemyHp <= 0)
            FSM.ChangeState(FSMState.Die);
        else if (enemyHp < arousalHp && !isArousal)
        {
            isArousal = true;
            FSM.ChangeState(FSMState.WakeUP);
        }
    }
}
