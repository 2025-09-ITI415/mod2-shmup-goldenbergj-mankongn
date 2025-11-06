using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class WeaponEnemy : MonoBehaviour
{
    public Weapon weapon;
    public bool weaponCooldown = true;
    public float fireEvery = 2f;
    public float initialDelay = 0.5f;

    float nextFireAt;
    Enemy enemy;
    Vector3 lastPos;

    void Awake()
    {
        enemy = GetComponent<Enemy>();
        if (weapon == null) weapon = GetComponentInChildren<Weapon>();
    }

    void OnEnable()
    {
        nextFireAt = Time.time + Random.Range(0f, initialDelay);
        lastPos = transform.position;
    }

    void Update()
    {
        if (weapon == null) return;

        Vector3 enemyMovement = transform.position - lastPos;
        Vector3 aimDir = enemyMovement.normalized;
        lastPos = transform.position;

        if (weaponCooldown)
        {
            if (Time.time >= nextFireAt) {
                weapon.TryFire(aimDir, false);
                nextFireAt = Time.time + 0.05f;
            }
        } else
        {
            if (Time.time >= nextFireAt) {
                weapon.TryFire(aimDir, true);
                nextFireAt = Time.time + Mathf.Max(0.05f, fireEvery);
            }
        }
    }
}