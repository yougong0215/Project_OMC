using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePrefab : MonoBehaviour
{
    [SerializeField] private float fireSpeed;

    private Rigidbody rb;
    private Vector3 fireDir;
    private float fireDmg;

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
        if (col.gameObject.TryGetComponent(out CharacterInfo _pl))
        {
            _pl.GetDamage(fireDmg);
            Destroy(gameObject);
        }
    }
}
