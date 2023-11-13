using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrustaspikanFireball : FirePrefab
{
    [Header("CrustaspikanOverridle")]
    [SerializeField] private float fireBallDmg;

    private ParticleSystem ps;

    protected override void Awake()
    {
        ps = GetComponent<ParticleSystem>();
        fireDmg = fireBallDmg;

        Invoke("PushEffect", 5f);
    }

    protected override void Update()
    {
        
    }

    private void PushEffect()
    {
        Destroy(gameObject);
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.TryGetComponent(out CharacterInfo _pl))
        {
            _pl.GetDamage(fireDmg);
        }
    }
}
