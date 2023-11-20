using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathState : CommonState
{
    [SerializeField] private CharacterController characterController;

    public override void EnterState()
    {
        _animator.SetDeathAnimation(true);
        _animator.OnAnimationEventTrigger += EventAction;
        _animator.OnAnimationEndTrigger += EndAction;

        characterController.enabled = false;

        Invoke("ExitState", 3f);
    }

    public override void ExitState()
    {
        Destroy(Character.gameObject);
    }

    public override void UpdateState()
    {
        _animator.SetDeathAnimation(false);
        _animator.OnAnimationEventTrigger -= EventAction;
        _animator.OnAnimationEndTrigger -= EndAction;
    }
}
