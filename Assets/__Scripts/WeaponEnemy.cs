using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class WeaponEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyProjectilePrefab;
    [SerializeField]
    private float projectileSpeed = 20f;
    public Weapon weapon;
    public bool weaponCooldown = false;
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
        if(enemyProjectilePrefab == null) return;

        Vector3 enemyMovement = transform.position - lastPos;
        Vector3 aimDir = enemyMovement.normalized;
        lastPos = transform.position;

        if (Time.time >= nextFireAt)
        {
            FireEnemyShot(aimDir);
            nextFireAt = Time.time + Mathf.Max(0.05f, fireEvery);
        }
    }

    void FireEnemyShot(Vector3 dir)
    {
        ProjectileEnemy p = weapon.MakeEnemyProjectile(enemyProjectilePrefab);

        if (p == null) return;

        Vector3 dirXY = Vector3.ProjectOnPlane(dir, Vector3.forward).normalized;
        p.transform.rotation = Quaternion.LookRotation(Vector3.forward, dirXY);
        p.vel = dirXY * projectileSpeed;
    }
}