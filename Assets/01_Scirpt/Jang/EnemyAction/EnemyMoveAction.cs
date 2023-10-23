using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveAction : CommonAction
{
    private NavMeshAgent agent;
    private Transform playerTrs;

    private void Start()
    {
        agent = Character.GetComponent<NavMeshAgent>();
        playerTrs = GameObject.FindWithTag("Player").transform;
    }

    protected override void Init()
    {
        
    }

    protected override void OnEventFunc()
    {
        agent.isStopped = false;
    }

    protected override void OnUpdateFunc()
    {
        agent.destination = playerTrs.position;
        Debug.Log(agent.isStopped);
    }

    protected override void OnEndFunc()
    {
        agent.isStopped = true;
    }
}
