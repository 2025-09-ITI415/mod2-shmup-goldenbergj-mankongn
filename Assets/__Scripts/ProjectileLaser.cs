using System.Collections;
using UnityEngine;

public class ProjectileLaser : MonoBehaviour
{
    public float speed = 40f;
    public float damagePerSecond = 30f;
    public float lifetime = 2f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        Enemy e = other.GetComponent<Enemy>();
        if (e != null)
        {
            e.TakeDamage(damagePerSecond * Time.deltaTime);
        }
    }
}
