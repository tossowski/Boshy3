using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    

    private Animator anim;
    private Rigidbody2D myRigidBody;
    public float moveSpeed;
    public float jumpForce;
    public GameObject projectile;
    private bool facingLeft;
    // Start is called before the first frame update
    void Start()
    {
        
        anim = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxisRaw("Horizontal");
        if (x != 0)
        {
            anim.SetBool("running", true);
            if (x > 0)
            {
                facingLeft = false;
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            }
            else if (x < 0)
            {
                facingLeft = true;
                transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            }
        } else
        {
            anim.SetBool("running", false);
        }
        

        transform.position = new Vector3(transform.position.x + x * moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        //myRigidBody.velocity = new Vector2(x).normalized * moveSpeed * Time.deltaTime;
        //isMoving = myRigidBody.velocity != new Vector2(0f, 0f);
        if (Input.GetKeyDown("x"))
        {
            attack();
        }

        if (Input.GetKeyDown("z"))
        {
            jump();
        }
    }

    void attack()
    {
        anim.SetBool("attacking", true);
    }


    void stopAttacking()
    {
        anim.SetBool("attacking", false);
    }

    void jump()
    {

        anim.SetBool("airborne", true);
        myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetBool("airborne", false);
    }
}
