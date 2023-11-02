using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyInfo : CharacterInfo
{
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = Stat.SPEED;
    }

    public override void GetDamage(float _damage)
    {
        base.GetDamage(_damage);
    }
}
