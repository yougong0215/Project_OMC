using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine_Jang;

public abstract class Enemy : MonoBehaviour
{
    protected enum State
    {
        Idle,
        Move,
        Attack
    }

    protected StateMachine_Jang.IdleState idleState;
    protected StateMachine_Jang.MoveState moveState;
    protected StateMachine_Jang.AttackState attackState;

    protected State state;
    protected StateMachine_Jang.FSM fsm;

    [HideInInspector] public GameObject player;
    [HideInInspector] public Animator anim;

    protected virtual void Awake()
    {
        player = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();

        state = State.Idle;

        idleState = new StateMachine_Jang.IdleState(this);
        moveState = new StateMachine_Jang.MoveState(this);
        attackState = new StateMachine_Jang.AttackState(this);
    }

    protected virtual void Start()
    {
        fsm = new StateMachine_Jang.FSM(idleState);
    }

    protected virtual void Update()
    {
        StateBrain();
        fsm.UpdateState();
    }

    protected void StateBrain()
    {
        switch (state)
        {
            case State.Idle:
                IdleNode();
                break;
            case State.Move:
                MoveNode();
                break;
            case State.Attack:
                AttackNode();
                break;
        }
    }

    protected abstract void IdleNode();
    protected abstract void MoveNode();
    protected abstract void AttackNode();


    protected void ChangeState(State newState)
    {
        state = newState;
        switch (state)
        {
            case State.Idle:
                fsm.ChangeState(idleState);
                break;
            case State.Move:
                fsm.ChangeState(moveState);
                break;
            case State.Attack:
                fsm.ChangeState(attackState);
                break;
        }
    }

    public void AnimEvtAttack()
    {
        attackState.isAttacking = true;
        attackState.OnAttack();
    }

    public void AnimEvtAttackinEnd()
        => attackState.isAttacking = false;
}
