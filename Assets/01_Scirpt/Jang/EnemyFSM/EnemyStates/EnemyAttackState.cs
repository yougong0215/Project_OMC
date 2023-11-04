using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : CommonState
{
    public EnemyWeaponStance weaponStance;
    [SerializeField] private float moveDec;
    [SerializeField] private LayerMask obstacleMask;

    [HideInInspector] public Transform playerTrs;

    private void Start()
    {
        playerTrs = GameObject.FindWithTag("Player").transform;

        Init?.Invoke();
    }

    public override void EnterState()
    {
        _animator.SetAttackAnimation(true);
        _animator.OnAnimationEventTrigger += EventAction;
        _animator.OnAnimationEndTrigger += EndAction;

        Init?.Invoke();
    }

    public override void UpdateState()
    {
        Vector3 dir = playerTrs.position - transform.position;
        Ray ray = new Ray(transform.position, dir);
        RaycastHit playerHit;
        bool isPlayer = Physics.Raycast(ray, out playerHit, moveDec, LayerMask.GetMask("Player"));
        bool isObstacle = Physics.Raycast(ray, moveDec, obstacleMask);

        if ((!isPlayer || isObstacle) && !weaponStance.IsAttacking())
        {
            fsm.ChangeState(FSMState.Run);
        }
        //if (!weaponStance.IsAttacking())
        //{
        //    fsm.ChangeState(FSMState.Run);
        //}

        UpdateAction?.Invoke();
    }

    public override void ExitState()
    {
        _animator.SetAttackAnimation(false);
        _animator.OnAnimationEventTrigger -= EventAction;
        _animator.OnAnimationEndTrigger -= EndAction;

        weaponStance.ExitAttack();
    }
}
