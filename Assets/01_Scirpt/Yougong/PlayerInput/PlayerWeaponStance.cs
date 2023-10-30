using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponStance : MonoBehaviour
{
    protected CharacterInfo _player;
    
    
    public WeaponSO _currentWeapon;
    /// <summary>
    /// 기본공격
    /// </summary>
    public Action Normal_Click_Left = null;
    
    /// <summary>
    /// 특수공격
    /// </summary>
    public Action Normal_Click_Right = null;
    
    /// <summary>
    /// Q 스킬
    /// </summary>
    public Action Active_Skill_1 = null;
    
    /// <summary>
    /// E 스킬
    /// </summary>
    public Action Active_Skill_2 = null;
    
    /// <summary>
    /// R 스킬
    /// </summary>
    public Action Active_Skill_3 = null;

    public void ChangeStance(WeaponSO _so)
    {
        Normal_Click_Left = null;
        Normal_Click_Right = null;
        Active_Skill_1 = null;
        Active_Skill_2 = null;
        Active_Skill_3 = null;
        
        
        _currentWeapon = _so;
        
        
        Normal_Click_Left += () =>
        {
            ColliderCast obj = Instantiate(_so.L_Click, transform);
            obj.Init(_player, _currentWeapon.Stat);
        };
        
        Normal_Click_Right += () =>
        {
            ColliderCast obj = Instantiate(_so.R_Click, transform);
            obj.Init(_player, _currentWeapon.Stat);
        };
        
        Active_Skill_1 += () =>
        {
            ColliderCast obj = Instantiate(_so.Q_Skill, transform);
            obj.Init(_player, _currentWeapon.Stat);
        };
        
        Active_Skill_2 += () =>
        {
            ColliderCast obj = Instantiate(_so.E_Skill, transform);
            obj.Init(_player, _currentWeapon.Stat);
        };
        
        Active_Skill_3 += () =>
        {
            ColliderCast obj = Instantiate(_so.R_Skill, transform);
            obj.Init(_player, _currentWeapon.Stat);
        };
    }
    
    
    
    
}
