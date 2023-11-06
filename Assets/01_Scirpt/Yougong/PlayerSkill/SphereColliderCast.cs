using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereColliderCast : ColliderCast
{

    private SphereCollider _sphere;
    protected override void Awake()
    {
        base.Awake();
        try
        {
            _sphere = GetComponent<SphereCollider>();
        }
        catch
        {
            Debug.LogError($"Is it not Proper Collider! : SphereCollider => {gameObject.name}");
        }
        if (transform.localScale != Vector3.one)
        {
            Debug.LogError($"Object : {gameObject.name} is Not Vector.oen(1,1,1)");
        }
    }
    public override Collider[] ReturnColliders()
    {
        return Physics.OverlapSphere(transform.position, _sphere.radius, _layer);
    }
    
    
}
