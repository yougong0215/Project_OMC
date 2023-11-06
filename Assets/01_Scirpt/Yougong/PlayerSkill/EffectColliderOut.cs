using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectColliderOut : MonoBehaviour
{
    private ColliderCast cols;
    private ParticleSystem[] a;
    public bool _dontEffectMove = false;
    private void Awake()
    {
         cols = GetComponent<ColliderCast>();
         cols.OnAnimEvnt += OutEffect;
         a = GetComponentsInChildren<ParticleSystem>();
    }

    public void OutEffect()
    {
        foreach (var effect in a)
        {
            effect.Play();
        }
    }

    public void Update()
    {
        if(_dontEffectMove==false)
            return;
        
        //Vector3 vec = cols.originVec;
        //vec.y = a[0].transform.position.y;
        //a[0].transform.position = vec;
    }
}
