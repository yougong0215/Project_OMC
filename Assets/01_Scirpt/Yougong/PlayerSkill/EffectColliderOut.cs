using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectColliderOut : MonoBehaviour
{
    private ColliderCast cols;
    private void Awake()
    {
         cols = GetComponent<ColliderCast>();
         cols.OnAnimEvnt += OutEffect;
    }

    public void OutEffect()
    {
        ParticleSystem[] a = GetComponentsInChildren<ParticleSystem>();
        foreach (var effect in a)
        {
            effect.Play();
        }
    }
}
