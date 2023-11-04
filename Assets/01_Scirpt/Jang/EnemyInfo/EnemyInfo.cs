using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyInfo : CharacterInfo
{
    [HideInInspector] public NavMeshAgent agent;
    [SerializeField] private float dashSpeed;

    private Transform playerTrs;
    private float agentSpeed;
    private bool isDashing = false;

    private void Start()
    {
        playerTrs = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agentSpeed = Stat.SPEED;
    }

    private void Update()
    {
        Dashing();
    }

    void Dashing()
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

            Debug.Log("´ë½¬");
            agent.isStopped = false;
            agent.speed *= dashSpeed;
            agent.SetDestination(playerTrs.position + transform.forward * 2);
        }
    }

    public override void GetDamage(float _damage)
    {
        base.GetDamage(_damage);
    }
}
