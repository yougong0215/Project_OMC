using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardSkillAction : ColliderSkillAction
{
    [SerializeField] float _speed = 40f;
    
    protected override void Hit(Transform tls)
    {
        
    }

    protected override void UpdateInvoke()
    {
//        Debug.Log("aAAA");
        _root.position += transform.forward * _speed * Time.deltaTime;
    }
}
