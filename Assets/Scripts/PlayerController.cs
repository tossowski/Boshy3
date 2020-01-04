using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sound;
using GlobalSettings;

public class PlayerController : MonoBehaviour
{
    

    private Animator anim;
    private GameObject menu;
    public bool UIOpen;
    private Rigidbody2D myRigidBody;
    public float moveSpeed;
    public float jumpForce;
    public GameObject projectile;
    private bool facingLeft;
    public bool secondJumpAvailable;
    private bool yeetEverything;


    private bool attackIsColliding;
    // Start is called before the first frame update
    void Start()
    {
        UIOpen = false;
        secondJumpAvailable = true;
        menu = GameObject.Find("Canvas").transform.Find("Menu").gameObject;
        menu.SetActive(false);
        anim = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        attackIsColliding = false;
        GlobalSettings.Settings.soundfxVolume = 0.4f;
    }

    // Update is called once per frame
    void Update()
    {

        if (yeetEverything)
        {
            return;
        }

        if (!anim.GetBool("SHINEI") && !UIOpen)
        {
            if (!anim.GetBool("attacking"))
            {
                move();
                if (!anim.GetBool("preJumpSquat"))
                {
                    attack();
                }
                

            }        
            jump();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0.0f;
            UIOpen = true;
            menu.SetActive(true);
        }

    }

    public Rigidbody2D getRigidBody()
    {
        return myRigidBody;
    }

    public Animator getAnimator()
    {
        return anim;
    }

    public void enterFreeFall()
    {
        anim.SetBool("freeFall", true);
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
        myRigidBody.velocity = new Vector2(x * moveSpeed, myRigidBody.velocity.y);
        //transform.position = new Vector3(transform.position.x + x * moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
    }

    void attack()
    {
        if (Input.GetKeyDown("x"))
        {

            anim.SetBool("attacking", true);
            if (!anim.GetBool("airborne"))
            {
                myRigidBody.velocity = new Vector2(0.0f, 0.0f);
            } 

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
        anim.SetBool("preJumpSquat", false);
    }


    void stopAttacking()
    {
        anim.SetBool("attacking", false);
    }

    void jump()
    {
        if (Input.GetKeyDown("z") && !anim.GetBool("attacking"))
        {
            myRigidBody.gravityScale = 7f;
            if (!anim.GetBool("airborne"))
            {
                anim.SetBool("preJumpSquat", true);
                anim.SetBool("airborne", true);
            } else if (secondJumpAvailable)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                anim.SetBool("doubleJump", true);
                secondJumpAvailable = false;
            }
            
        }   
    }

    public void setDoubleJumpFalse()
    {
        anim.SetBool("doubleJump", false);
    }

    public void setPreJumpSquatFalse()
    {
        anim.SetBool("preJumpSquat", false);
    }

    public void setAirborneFalse()
    {
        anim.SetBool("airborne", false);
        anim.SetBool("doubleJump", false);
        anim.SetBool("freeFall", false);
        anim.SetBool("attacking", false);
        anim.SetBool("running", false);
        anim.SetBool("preJumpSquat", false);
        secondJumpAvailable = true;
    }

    public void setAirborneTrue()
    {
        anim.SetBool("airborne", true);
    }

    public void setAttackColliding(bool val)
    {
        attackIsColliding = val;
    }

    public void playSound(String sound)
    {
        Sound.SoundFX.playSound("SoundFX/" + sound, false, GlobalSettings.Settings.soundfxVolume);
    }

    public void playAttackSound(String sound)
    {
        if (attackIsColliding)
        {
            Sound.SoundFX.playSound("SoundFX/Hit", false, GlobalSettings.Settings.soundfxVolume);
        } else
        {
            Sound.SoundFX.playSound("SoundFX/" + sound + "Miss", false, GlobalSettings.Settings.soundfxVolume);
        }
    }

    public void yeetPlayerMovement()
    {
        yeetEverything = true;
        myRigidBody.velocity = Vector2.zero;
        anim.SetBool("running", false);
    }

    public void resumePlayerMovement()
    {
        yeetEverything = false;
    }

}
