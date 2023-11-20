using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyInfo : CharacterInfo
{
    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public bool isAttack;
    [Header("속공 없으면 안넣어도 됨")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashIntersection = 1.5f;

    protected EnemyHpBar hpBar;
    protected Transform playerTrs;
    protected float enemyHp;
    protected float agentSpeed;
    protected bool isDashing = false;

    protected virtual void Start()
    {
        hpBar = GetComponentInChildren<EnemyHpBar>();
        playerTrs = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();

        enemyHp = statSo.HP;
        agentSpeed = Stat.SPEED;

        hpBar.SetHpBar(enemyHp, statSo.HP);
    }

    protected virtual void Update()
    {
        Dashing();
    }

    private void Dashing()
    {
        if (isDashing)
        {
            if (agent.remainingDistance <= dashIntersection || FSM.NowState() != FSMState.Attack)
            {
                isDashing = false;

                agent.enabled = false;
                agent.enabled = true;
                agent.isStopped = true;
                agent.speed = agentSpeed;
            }
        }
    }

    public void DashInit()
    {
        if (!isDashing)
        {
            isDashing = true;

            agent.isStopped = false;
            agent.speed *= dashSpeed;
            agent.SetDestination(playerTrs.position + transform.forward * 2);
        }
    }

    public override void GetDamage(float _damage, bool _nuckBack = true)
    {
        _damage = 10;
        enemyHp -= _damage;

        hpBar.SetHpBar(enemyHp, statSo.HP);

        if (enemyHp <= 0)
            FSM.ChangeState(FSMState.Die);
        else if(_nuckBack)
            FSM.ChangeState(FSMState.Hit);
    }
}
