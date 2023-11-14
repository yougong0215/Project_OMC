using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CrustaspikanInfo : EnemyInfo
{
    [Header("CrustaspikanOverride")]
    [SerializeField] private Slider hpBar;
    [SerializeField] private ParticleSystem arousalParticle;
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

        hpBar.maxValue = enemyHp;
        hpBar.value = hpBar.maxValue;
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.F))
        {
            isArousal = true;
            AnimCon.Animator.speed = 1.3f;
            arousalParticle.Play();
            Arousal();
            FSM.ChangeState(FSMState.WakeUP);
        }
    }

    public void RandomPatten()
    {
        int idx = UnityEngine.Random.Range(0, pattens.Count);
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

    private void Arousal()
    {
        pattens.Clear();

        pattens.Add(new Tuple<AttackEnum, float>(AttackEnum.POWER, powDec));
        pattens.Add(new Tuple<AttackEnum, float>(AttackEnum.SPEED, sedDec));
        pattens.Add(new Tuple<AttackEnum, float>(AttackEnum.THROW, thrDec));
    }

    public override void GetDamage(float _damage, bool _nuckBack = false)
    {
        Debug.Log($"데미지 얼마? {_damage}");
        _damage = 10;
        enemyHp -= _damage;
        hpBar.value = enemyHp;

        if (enemyHp <= 0)
        {
            arousalParticle.Stop();
            FSM.ChangeState(FSMState.Die);
        }
        else if (enemyHp < arousalHp && !isArousal)
        {
            isArousal = true;
            AnimCon.Animator.speed = 1.3f;
            arousalParticle.Play();
            Arousal();
            FSM.ChangeState(FSMState.WakeUP);
        }
    }
}
