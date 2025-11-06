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

    void Awake()
    {
        enemy = GetComponent<Enemy>();
        if (weapon == null) weapon = GetComponentInChildren<Weapon>();
    }

    void OnEnable()
    {
        nextFireAt = Time.time + Random.Range(0f, initialDelay);
    }

    void Update()
    {
        if (weapon == null) return;

        if (weaponCooldown)
        {
            if (Time.time >= nextFireAt) {
                weapon.TryFire();
                nextFireAt = Time.time + 0.05f;
            }
        } else
        {
            if (Time.time >= nextFireAt) {
                weapon.TryFire();
                nextFireAt = Time.time + Mathf.Max(0.05f, fireEvery);
            }
        }
    }
}