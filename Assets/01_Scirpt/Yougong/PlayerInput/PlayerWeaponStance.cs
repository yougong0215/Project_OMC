using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponStance : MonoBehaviour
{
    protected CharacterInfo _player;

    private PlayerInput _input;
    
    public PlayerWeaponSO _currentWeapon;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
    }

    public void ChangeStance(PlayerWeaponSO _so)
    {
         _input.SkillInputReset();
        
        _currentWeapon = _so;
        
        
        _input.OnLeftClick += () =>
        {
            ColliderCast obj = Instantiate(_so.L_Click, transform);
            obj.Init(_player, _currentWeapon.Stat);
        };
        
        _input.OnRightClick += () =>
        {
            ColliderCast obj = Instantiate(_so.R_Click, transform);
            obj.Init(_player, _currentWeapon.Stat);
        };
        
        _input.Q_Btn += () =>
        {
            ColliderCast obj = Instantiate(_so.Q_Skill, transform);
            obj.Init(_player, _currentWeapon.Stat);
        };
        
        _input.E_Btn += () =>
        {
            ColliderCast obj = Instantiate(_so.E_Skill, transform);
            obj.Init(_player, _currentWeapon.Stat);
        };
        
        _input.R_Btn += () =>
        {
            ColliderCast obj = Instantiate(_so.R_Skill, transform);
            obj.Init(_player, _currentWeapon.Stat);
        };
    }
    
    
    
    
}
