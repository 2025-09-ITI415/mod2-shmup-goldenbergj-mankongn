using UnityEngine;

public class ShotAnchor : MonoBehaviour
{
    public Transform target; // Ship that's shooting
    public Vector2 offset; // Distance from ship

    void LateUpdate()
    {
        if (!target) return;

        var p = target.position;
        transform.position = new Vector3(p.x + offset.x, p.y + offset.y, 0f);
        transform.rotation = Quaternion.identity;
    }
}