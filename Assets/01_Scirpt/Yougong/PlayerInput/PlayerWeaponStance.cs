using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponStance : MonoBehaviour
{
    protected PlayerInfo _player;

    private PlayerInput _input;
    
    public PlayerWeaponSO _currentWeapon;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _player = GetComponent<PlayerInfo>();
    }

    public void ChangeStance(PlayerWeaponSO _so)
    {
         _input.SkillInputReset();
        
        _currentWeapon = _so;
        
        
        _input.OnLeftClick += () =>
        {
            if (_so.L_Click == null)
                return;
            
            ColliderCast obj = Instantiate(_so.L_Click, transform);
            obj.Init(_player, _currentWeapon.Stat);
        };
        
        _input.OnRightClick += () =>
        {
            if (_so.R_Click == null)
                return;
            ColliderCast obj = Instantiate(_so.R_Click, transform);
            obj.Init(_player, _currentWeapon.Stat);
        };
        
        _input.Q_Btn += () =>
        {
            if (_so.Q_Skill == null)
                return;
            ColliderCast obj = Instantiate(_so.Q_Skill, transform);
            obj.Init(_player, _currentWeapon.Stat);
        };
        
        _input.E_Btn += () =>
        {
            if (_so.E_Skill == null)
                return;
            ColliderCast obj = Instantiate(_so.E_Skill, transform);
            obj.Init(_player, _currentWeapon.Stat);
        };
        
        _input.R_Btn += () =>
        {
            if (_so.R_Skill == null)
                return;
            ColliderCast obj = Instantiate(_so.R_Skill, transform);
            obj.Init(_player, _currentWeapon.Stat);
        };
    }
    
    
    
    
}
