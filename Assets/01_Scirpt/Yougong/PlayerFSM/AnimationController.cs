using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    private readonly int _isRunHash = Animator.StringToHash("is_move");
    private readonly int _isRunXHash = Animator.StringToHash("MoveX");
    private readonly int _isRunYHash = Animator.StringToHash("MoveY");
    private readonly int _RunTriggerhash = Animator.StringToHash("run");

    private readonly int _isAttackHash = Animator.StringToHash("is_Attack");
    private readonly int _AttackTriggerhash = Animator.StringToHash("_attack");

    private readonly int _isHitHash = Animator.StringToHash("is_Hit");
    private readonly int _hitTriggerhash = Animator.StringToHash("_hit");

    private readonly int _isNuckHash = Animator.StringToHash("is_Nuck");
    private readonly int _nuckTriggerhash = Animator.StringToHash("nuckdown");

    private readonly int _isWakeHash = Animator.StringToHash("is_wake");
    private readonly int _wakeTriggerhash = Animator.StringToHash("wakeUP");

    private readonly int _isDashHash = Animator.StringToHash("is_dash");
    private readonly int _dashTriggerhash = Animator.StringToHash("dash");

    private readonly int _isDeathHash = Animator.StringToHash("is_death");
    private readonly int _deathTriggerhash = Animator.StringToHash("death");

    public event Action OnAnimationEndTrigger = null;
    public event Action OnAnimationEventTrigger = null;
    public event Action OnPreAnimationEventTrigger = null;


    [SerializeField] AnimatorOverrideController AOC;
    [SerializeField] Avatar av;

    private Animator _animator;
    public Animator Animator => _animator;
    public AnimatorOverrideController _changeAnimation => AOC;

    FSM _fsm;
    //이미지 메이킹
    private void Awake()
    {
            _animator = GetComponent<Animator>();

        
        _fsm = transform.parent.GetComponent<FSM>();
    }


    public void ChangeAnimationClip(FSMState fsm, AnimationClip clip)
    {
        AOC[fsm.ToString()] = clip;
        Debug.LogWarning(_animator);
        if (_animator == null)
        {
            _animator = GetComponent<Animator>();
        }
        
        _animator.runtimeAnimatorController = AOC;
    }

    public void SetDashAnimation(bool b)
    {
        if (b == true)
        {
            _animator.SetBool(_isDashHash, b);
            _animator.SetTrigger(_dashTriggerhash);
        }
        else
        {
            _animator.SetBool(_isDashHash, b);
            _animator.ResetTrigger(_dashTriggerhash);
        }
    }

    public void OnAnimationEvent()
    {
        OnAnimationEventTrigger?.Invoke();
    }
    public void OnAnimationEnd()
    {
//        print("ㅁㅁㅁ");
        OnAnimationEndTrigger?.Invoke();
    }

    public void SetHitAnimation(bool b)
    {
        if (b == true)
        {
            _animator.SetBool(_isHitHash, b);
            _animator.SetTrigger(_hitTriggerhash);
        }
        else
        {
            _animator.SetBool(_isHitHash, b);
            _animator.ResetTrigger(_hitTriggerhash);
        }
    }


    public void SetWakeAnimation(bool b)
    {
        if (b == true)
        {
            _animator.SetBool(_isWakeHash, b);
            _animator.SetTrigger(_wakeTriggerhash);
        }
        else
        {
            _animator.SetBool(_isWakeHash, b);
            _animator.ResetTrigger(_wakeTriggerhash);
        }
    }
    public void SetNuckDownAnimation(bool b)
    {
        if (b == true)
        {
            _animator.SetBool(_isNuckHash, b);
            _animator.SetTrigger(_nuckTriggerhash);
        }
        else
        {
            _animator.SetBool(_isNuckHash, b);
            _animator.ResetTrigger(_nuckTriggerhash);
        }
    }

    public void SetDeathAnimation(bool b)
    {
        if (b == true)
        {
            _animator.SetBool(_isDeathHash, b);
            _animator.SetTrigger(_deathTriggerhash);
        }
        else
        {
            _animator.SetBool(_isDeathHash, b);
            _animator.ResetTrigger(_deathTriggerhash);
        }
    }

    public void SetMoveAnimation(bool b)
    {
        _animator.SetBool(_isRunHash, b);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        _animator.SetFloat(_isRunXHash, dir.x);
        _animator.SetFloat(_isRunYHash, dir.y);
    }

    public void SetAttackAnimation(bool b)
    {
        if(b== true)
        {
            _animator.SetBool(_isAttackHash, b);
            _animator.SetTrigger(_AttackTriggerhash);
        }
        else
        {
            _animator.SetBool(_isAttackHash, b);
            _animator.ResetTrigger(_AttackTriggerhash);
        }
    }
}
