using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Stat")]
public class CharacterStat : ScriptableObject
{
    public float HP
    {
        get;
        set;
    } = 100;
    public float ATK
    {
        get;
        set;
    } = 10;
    public float DEF 
    {
        get;
        set;
    } = 0;
        
    /// <summary>
    /// 계수
    /// </summary>
    public float SPEED 
    {
        get;
        set;
    } = 1;

    public float Crit
    {
        get;
        set;
    } = 0;

    /// <summary>
    /// 계수
    /// </summary>
    public float CritAmp
    {
        get;
        set;
    } = 1;
    
    /// <summary>
    /// 스킬 쿨타임
    /// </summary>
    public float COOLDOWN
    {
        get;
        set;
    } = 1;
    
}