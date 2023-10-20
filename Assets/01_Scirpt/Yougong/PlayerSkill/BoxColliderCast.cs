using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderCast : ColliderCast
{
    private BoxCollider _box;
    private void Awake()
    {
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

    public override Collider[] ReturnColliders()
    {
        return Physics.OverlapBox(transform.position, _box.size/2, _player.rotation, _layer );
    }
}
