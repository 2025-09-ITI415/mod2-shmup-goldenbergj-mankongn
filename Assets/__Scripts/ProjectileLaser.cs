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
    transform.position += Vector3.up * speed * Time.deltaTime;
    Debug.DrawRay(transform.position, Vector3.up * 2, Color.cyan);
    Debug.Log($"Laser pos {transform.position} world up {Vector3.up}");
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
