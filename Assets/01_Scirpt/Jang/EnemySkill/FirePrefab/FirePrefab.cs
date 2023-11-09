using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FirePrefab : MonoBehaviour
{
    [SerializeField] private GameObject bombParticle;
    [SerializeField] private float fireSpeed;
    [SerializeField] private LayerMask playerMask;

    private Rigidbody rb;

    private Vector3 fireDir;
    private float fireDmg;

    const float partcleDestroyTime = 1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void FireSetting(Vector3 targetPos, float dmg)
    {
        fireDmg = dmg;
        fireDir = targetPos - transform.position;
        transform.rotation = Quaternion.LookRotation(fireDir);
    }

    private void Update()
    {
        rb.velocity = fireDir.normalized * fireSpeed;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.TryGetComponent(out CharacterInfo _pl) && col.gameObject.layer == playerMask)
        {
            _pl.GetDamage(fireDmg);
        }

        GameObject partcle = Instantiate(bombParticle, transform.position, Quaternion.identity);
        ParticleSystem[] a = partcle.GetComponentsInChildren<ParticleSystem>();
        foreach (var effect in a)
            effect.Play();

        Destroy(partcle, partcleDestroyTime);
        Destroy(gameObject);
    }
}
