using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Skill/Player/Forward")]
public class SkillForwardMoveSO : SkillSO
{
    [Header("나아가는 속도")]
    public float _speed;
    [Description("0.05배 가속")]
    public override void SkillUpdate()
    {
        //base.SkillUpdate();
        _info.transform.position += _info.transform.forward * _speed * 0.05f * Time.deltaTime;
        
    }
}
