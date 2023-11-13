using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderCast : ColliderCast
{
    private BoxCollider _box;
    protected override void Awake()
    {
        base.Awake();
        try
        {
            _box = GetComponent<BoxCollider>();
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

    private void OnDrawGizmos()
    {
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireCube(Vector3.zero, _box.size);
    }

    public override Collider[] ReturnColliders()
    {

        
        return Physics.OverlapBox(transform.position + _box.center, _box.size, transform.rotation, _layer);
    }
}
