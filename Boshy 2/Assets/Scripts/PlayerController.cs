using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D myRigidBody;
    public float moveSpeed;
    public GameObject projectile;
    private bool facingLeft;
    private int jumpsLeft;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        jumpsLeft = 10;
    }

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxisRaw("Horizontal");
        if (x > 0)
        {
            facingLeft = false;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        } else if (x < 0)
        {
            facingLeft = true;
            transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        }

        transform.position = new Vector3(transform.position.x + x * moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        //myRigidBody.velocity = new Vector2(x).normalized * moveSpeed * Time.deltaTime;
        //isMoving = myRigidBody.velocity != new Vector2(0f, 0f);
        if (Input.GetKeyDown("x"))
        {
            shoot();
        }

        if (Input.GetKeyDown("z"))
        {
            jump();
        }
    }

    void shoot()
    {
        var clone = (GameObject)Instantiate(projectile, transform.position, Quaternion.Euler(new Vector3(0f, 0f, 0f)));
        clone.GetComponent<projectileController>().shoot(facingLeft);
    }

    void jump()
    {
        if (jumpsLeft > 0)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, 17.0f);
            jumpsLeft--;
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
    }
}
