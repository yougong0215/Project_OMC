using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInputOutputAction : CommonAction
{
    public PlayerWeaponStance _weapon;
    protected override void Init()
    {
        
    }

    protected override void OnEventFunc()
    {
        _weapon._CurrentSkill?.CurrentObject?.Attack(true);
    }

    protected override void OnEndFunc()
    { 
//        Debug.Log("Out");
        _weapon._CurrentSkill?.CurrentObject?.Attack(false);
    }

    protected override void OnUpdateFunc()
    {

    }


}
