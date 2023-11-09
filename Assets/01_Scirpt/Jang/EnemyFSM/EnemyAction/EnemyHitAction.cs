using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitAction : CommonAction
{
    [SerializeField] private float knockbackAmount;
    [SerializeField] private float knockbackSpeed;

    private Transform playerTrs;

    private Vector3 dir;
    private Vector3 targetPosition;

    private void Start()
    {
        playerTrs = GameObject.FindWithTag("Player").transform;
    }

    protected override void Init()
    {
        
    }

    protected override void OnEventFunc()
    {
        Debug.Log("D");
        dir = Character.position - playerTrs.position;
        targetPosition = Character.position + dir * knockbackAmount;
    }

    protected override void OnEndFunc()
    {
        Debug.Log("DD");
        com.FSMMain.ChangeState(FSMState.Idle);
    }

    protected override void OnUpdateFunc()
    {
        Vector3 newPosition = Vector3.MoveTowards(Character.position, targetPosition, knockbackSpeed * Time.deltaTime);
        newPosition.y = Character.position.y;
        Character.position = newPosition;
    }
}
