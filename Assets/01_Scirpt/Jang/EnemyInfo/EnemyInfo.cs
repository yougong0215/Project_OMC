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

    private Transform playerTrs;
    private float enemyHp;
    private float agentSpeed;
    private bool isDashing = false;

    private void Start()
    {
        playerTrs = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();

        enemyHp = statSo.HP;
        agentSpeed = Stat.SPEED;
    }

    private void Update()
    {
        Dashing();
    }

    private void Dashing()
    {
        if (isDashing)
        {
            if (agent.remainingDistance <= 1.5f || FSM.NowState() != FSMState.Attack)
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

            Debug.Log("대쉬");
            agent.isStopped = false;
            agent.speed *= dashSpeed;
            agent.SetDestination(playerTrs.position + transform.forward * 2);
        }
    }

    public override void GetDamage(float _damage)
    {
        enemyHp -= _damage;

        if (enemyHp <= 0)
            FSM.ChangeState(FSMState.Die);
        else
            FSM.ChangeState(FSMState.Hit);
    }
}
