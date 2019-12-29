using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class Skeleton : Enemy
{

    private bool facingLeft;
    private bool attacking;
    public float maxSpeed;
    

    // Update is called once per frame
    public override void Update()
    {
        if (!anim.GetBool("hitstun"))
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
                myrigidbody.velocity = new Vector2(maxSpeed, myrigidbody.velocity.y);
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            }
            else if (x < 0)
            {
                facingLeft = true;
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
