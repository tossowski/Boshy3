﻿using System.Collections;
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

        
        if (!anim.GetBool("SHINEI"))
        {
            move();
            attack();
            jump();
        }

    }

    private void move()
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
        }
        else
        {
            anim.SetBool("running", false);
        }
        transform.position = new Vector3(transform.position.x + x * moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
    }

    void attack()
    {
        if (Input.GetKeyDown("x") && !anim.GetBool("airborne"))
        {
            anim.SetBool("attacking", true);
        }
         
            
    }

    void jumpSquat()
    {
        if (!Input.GetKey("z"))
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce / 1.5f);
        } else
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
        }
    }


    void stopAttacking()
    {
        anim.SetBool("attacking", false);
    }

    void jump()
    {
        if (!anim.GetBool("airborne") && Input.GetKeyDown("z"))
        {
            anim.SetBool("airborne", true);
            //myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
        }
        
    }

    public void setAirborneFalse()
    {
        anim.SetBool("airborne", false);
    }
}
