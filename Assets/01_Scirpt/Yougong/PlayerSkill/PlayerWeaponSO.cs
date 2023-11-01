using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Player/Weapon")]
public class PlayerWeaponSO : WeaponSO
{
    [Header("좌클릭")]
    public PlayerSkillListSO L_Click;

    [Header("우클릭")]
    public PlayerSkillListSO R_Click;
    
    [Header("Q 스킬")]
    public PlayerSkillListSO Q_Skill;

    [Header("E 스킬")]
    public PlayerSkillListSO E_Skill;

    [Header("R 스킬")]
    public PlayerSkillListSO R_Skill;

    
}
