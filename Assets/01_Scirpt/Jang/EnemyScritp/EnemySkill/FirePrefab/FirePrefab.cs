using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FirePrefab : MonoBehaviour
{
    [SerializeField] private GameObject bombParticle;
    [SerializeField] private float fireSpeed;
    [SerializeField] private LayerMask playerMask;

    protected Rigidbody rb;

    protected Vector3 fireDir;
    protected float fireDmg;

    const float partcleDestroyTime = 1f;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public virtual void FireSetting(Vector3 targetPos, float dmg)
    {
        fireDmg = dmg;
        targetPos.y += 1;
        fireDir = targetPos - transform.position;
        transform.rotation = Quaternion.LookRotation(fireDir);
    }

    protected virtual void Update()
    {
        rb.velocity = fireDir.normalized * fireSpeed;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.TryGetComponent(out PlayerInfo _pl) && col.gameObject.layer == playerMask)
        {
            _pl.GetDamage(fireDmg);
        }

        Debug.Log(col.transform.name);

        GameObject partcle = Instantiate(bombParticle, transform.position, Quaternion.identity);
        ParticleSystem[] a = partcle.GetComponentsInChildren<ParticleSystem>();
        foreach (var effect in a)
            effect.Play();

        Destroy(partcle, partcleDestroyTime);
        Destroy(gameObject);
    }
}
