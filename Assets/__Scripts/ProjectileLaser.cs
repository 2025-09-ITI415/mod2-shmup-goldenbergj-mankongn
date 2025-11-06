using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaser : MonoBehaviour
{
    public float speed = 40f;
    public float lifetime = 2f;
    public float damagePerSecond = 30f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // Move the beam upward (same direction as normal projectiles)
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        // Deal damage over time while touching enemies
        Enemy e = other.GetComponent<Enemy>();
        if (e != null)
        {
            e.TakeDamage(damagePerSecond * Time.deltaTime);
        }
    }
}
