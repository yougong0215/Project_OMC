using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerInfo : CharacterInfo
{
    private PlayerInput _input;
    public PlayerInput Input => _input;

    private PlayerMovement _move;
    public PlayerMovement Move => _move;
    protected override void AwakeInvoke()
    {
        _input = GetComponent<PlayerInput>();
        _move = GetComponent<PlayerMovement>();
    }
}
