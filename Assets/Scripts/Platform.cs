using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public bool vertical;
    public bool loop;
    public float leftSpace;
    public float rightSpace;
    public float speed;
    private float start;
    private bool playerOn;
    private PlayerController player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        if (vertical)
        {
            start = transform.position.y;
        } else
        {
            start = transform.position.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (vertical)
        {
            if (transform.position.y < start - leftSpace || transform.position.y > start + rightSpace)
            {
                speed = -speed;
                transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime);
            }
            transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime);
        } else
        {
            if (transform.position.x < start - leftSpace || transform.position.x > start + rightSpace)
            {
                speed = -speed;
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y);
            }
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerOn = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerOn = false;
        }
    }

    void LateUpdate()
    {
        if (playerOn && !vertical)
        {
            if (player.getAnimator().GetBool("attacking"))
            {
                player.getRigidBody().velocity = new Vector2(speed, 0.0f);
            } else
            {
                player.getRigidBody().velocity += new Vector2(speed, 0.0f);
            }
            
        }
    }
}
