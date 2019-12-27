using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{

    private bool facingLeft;
    private bool attacking;
    private bool isInHitStun;
    public float maxSpeed;

    // Update is called once per frame
    public override void Update()
    {
        if (!isInHitStun)
        {
            attack();
            move();
        }
        
    }

    public override void move()
    {
        float x = player.transform.position.x - transform.position.x;
        
        if (x != 0)
        {
            if (x > 0)
            {
                facingLeft = false;
                //if (myrigidbody.velocity.magnitude < maxSpeed)
                //{
                //    myrigidbody.AddForce(new Vector2(70.0f, 0.0f), ForceMode2D.Impulse);
                //}
                myrigidbody.velocity = new Vector2(maxSpeed, myrigidbody.velocity.y);
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            }
            else if (x < 0)
            {
                facingLeft = true;
                //if (myrigidbody.velocity.magnitude < maxSpeed)
                //{
                //    myrigidbody.AddForce(new Vector2(-70.0f, 0.0f), ForceMode2D.Impulse);
                //}
                myrigidbody.velocity = new Vector2(-maxSpeed, myrigidbody.velocity.y);
                transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            }
        }

        if (attacking)
        {
            myrigidbody.velocity = new Vector2(0.0f, myrigidbody.velocity.y);
        }
    }

    public void onHitEnd()
    {
        anim.SetBool("hitstun", false);
    }

    public void onHitStart()
    {
        isInHitStun = true;
    }

    public void setHitStunOff()
    {
        isInHitStun = false;
    }


    public override void attack()
    {
        if (!attacking && Vector3.Distance(player.transform.position, transform.position) < attackRange)
        {
            attacking = true;
            anim.SetBool("attacking", true);
        }
    }

    public void setAttackingTrue()
    {
        attacking = false;
        anim.SetBool("attacking", false);
    }
}
