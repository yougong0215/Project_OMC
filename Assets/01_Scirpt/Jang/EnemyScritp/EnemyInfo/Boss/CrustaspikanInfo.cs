using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class CrustaspikanInfo : EnemyInfo
{
    public event Action OnDeathEvt;

    [Header("CrustaspikanOverride")]
    [SerializeField] private new Slider hpBar;
    [SerializeField] private ParticleSystem arousalParticle;
    [SerializeField] private float arousalHp;
    [SerializeField] private string clearSceneName;
    [Header("공격 범위")]
    [SerializeField] protected float nor1Dec, nor2Dec, nor3Dec, powDec, sedDec, thrDec;
    [HideInInspector] public bool isArousal;

    private List<Tuple<AttackEnum, float>> pattens = new List<Tuple<AttackEnum, float>>();
    private Tuple<AttackEnum, float> currentPatten;

    protected override void Start()
    {
        playerTrs = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();

        pattens.Add(new Tuple<AttackEnum, float>(AttackEnum.NORMAL1, nor1Dec));
        pattens.Add(new Tuple<AttackEnum, float>(AttackEnum.NORMAL2, nor2Dec));
        pattens.Add(new Tuple<AttackEnum, float>(AttackEnum.NORMAL3, nor3Dec));

        enemyHp = statSo.HP;
        agentSpeed = Stat.SPEED;
        hpBar.maxValue = enemyHp;
        hpBar.value = hpBar.maxValue;
    }

    protected override void Update()
    {
        base.Update();
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    isArousal = true;
        //    AnimCon.Animator.speed = 1.3f;
        //    arousalParticle.Play();
        //    Arousal();
        //    FSM.ChangeState(FSMState.WakeUP);
        //}
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

    public void BossDeath()
    {
        OnDeathEvt?.Invoke();
        SceneManager.LoadScene("ClearScene");
    }

    public override void GetDamage(float _damage, bool _nuckBack = false)
    {
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
