using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class EnemyAttackAction : CommonAction
{
    [SerializeField] private float rotationSpeed;

    private EnemyWeaponStance weaponStance;
    private Transform playerTrs;

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

    protected override void OnEndFunc()
    {
        weaponStance.Attack(false);

        //Vector3 targetDirection = playerTrs.position - Character.position;

        //// y 방향만 고려한 각도 계산
        //float targetAngle = Mathf.Atan2(targetDirection.x, targetDirection.z) * Mathf.Rad2Deg;

        //// Mathf.LerpAngle을 사용하여 y 방향 회전을 부드럽게 조절
        //float currentAngle = Mathf.LerpAngle(Character.eulerAngles.y, targetAngle, rotationSpeed * Time.deltaTime);

        //// 새로운 회전 값을 설정
        //Character.rotation = Quaternion.Euler(0, currentAngle, 0);
    }
}
