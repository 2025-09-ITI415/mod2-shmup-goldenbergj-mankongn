using UnityEngine;

[RequireComponent(typeof(BoundsCheck))]
public class ProjectileEnemy : MonoBehaviour
{
    BoundsCheck bnd;
    Renderer rend;
    public Rigidbody rigid;

    void Awake()
    {
        bnd = GetComponent<BoundsCheck>();
        rend = GetComponent<Renderer>();
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!bnd.isOnScreen)
        {
            Destroy(gameObject);
        }
    }

    public Vector3 vel
    {
        get { return rigid.linearVelocity; }
        set { rigid.linearVelocity = value; }
    }
}