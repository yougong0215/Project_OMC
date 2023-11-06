using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ColliderSkillAction : MonoBehaviour
{
    private bool _init = false;
    protected Transform _root;
    private ColliderCast _col;
    
    public virtual void Reset(ColliderCast cols, Transform tls)
    {
        transform.position = tls.position;
        transform.rotation = tls.rotation;
        _col = cols;
        _root = tls;
        _init = true;
        Debug.Log("Reset");
    }


    protected virtual void Update()
    {
        if (_init == false)
            return;
        if(_col.IsAttack==true)
            UpdateInvoke();
        
        
    }
    
    protected abstract void Hit(Transform tls);
    protected abstract void UpdateInvoke();
}
