using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrustaspikanFireball : FirePrefab
{
    private ParticleSystem ps;

    protected override void Awake()
    {
        ps = GetComponent<ParticleSystem>();

        Invoke("PushEffect", 7f);
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
        if (other.TryGetComponent(out PlayerInfo _pl))
        {
            _pl.GetDamage(fireDmg, true);
        }
    }
}
