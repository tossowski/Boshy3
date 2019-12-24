using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour
{

    public float range;
    protected Rigidbody2D myRigidBody;
    public float moveSpeed;

    private bool facingLeft;

    void Awake()
    {
        Destroy(gameObject, range);
    }

    public void shoot(bool direction)
    {
        facingLeft = direction;
        shoot();
    }

    public virtual void shoot()
    {
        Vector2 direction = new Vector2(1.0f, 0.0f);
        if (facingLeft)
        {
            direction = new Vector2(-1.0f, 0.0f);
        }
        myRigidBody = GetComponent<Rigidbody2D>();
        myRigidBody.velocity = (direction * moveSpeed);
        transform.Rotate(new Vector3(0f, 0f, 180 * Mathf.Atan2(direction.y, direction.x) / Mathf.PI));
    }
}
