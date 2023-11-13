using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class EnemyAttackAction : CommonAction
{
    [SerializeField] private float rotationSpeed;

    protected EnemyWeaponStance weaponStance;
    protected Transform playerTrs;

    protected override void Init()
    {
        weaponStance = com.GetComponent<EnemyAttackState>().weaponStance;
        playerTrs = com.GetComponent<EnemyAttackState>().playerTrs;
    }

    protected override void OnEventFunc()
    {
        weaponStance.NowColliderCase().CheckDic = new();
        weaponStance.Attack(true);
    }

    protected override void OnEndFunc()
    {
        
        weaponStance.Attack(false);
    }

    protected override void OnUpdateFunc()
    {
        if (!weaponStance.IsAttacking())
        {
            Vector3 targetDirection = playerTrs.position - Character.position;
            float targetAngle = Mathf.Atan2(targetDirection.x, targetDirection.z) * Mathf.Rad2Deg;
            float currentAngle = Mathf.LerpAngle(Character.eulerAngles.y, targetAngle, rotationSpeed * Time.deltaTime);

            Character.rotation = Quaternion.Euler(0, currentAngle, 0);
        }
    }
}
