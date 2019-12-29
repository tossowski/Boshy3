using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Rigidbody2D myrigidbody;
    protected GameObject player;
    protected Animator anim;
    public int maxHealth;
    public int currHealth;
    public float attackRange;
    public GameObject damageLoc;
    // Start is called before the first frame update
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public virtual void move()
    {

    }

    public virtual void attack()
    {

    }

    public virtual void damage(int n)
    {
        currHealth -= n;
        if (currHealth <= 0)
        {
            deathrattle();
        }
    }

    public virtual void deathrattle()
    {
        myrigidbody.velocity = Vector2.zero;
        anim.SetBool("SHINEI", true);
        Destroy(gameObject, 1.0f);
    }

    public virtual void hitStun()
    {
        anim.SetBool("hitstun", true);
        string[] tokens = gameObject.name.Split(' ');
        anim.Play(tokens[0] + "Hit", -1, 0.0f);
        Debug.Log(tokens[0]);
    }
}
