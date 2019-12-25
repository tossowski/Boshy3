using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Animator anim = collision.gameObject.GetComponent<Animator>();
            anim.SetBool("hitstun", true);
            Vector3 dirVector = Vector3.Normalize(new Vector3(1.0f, 1.0f, 0.0f));
            if (collision.gameObject.transform.position.x < player.transform.position.x)
            {
                dirVector = Vector3.Normalize(new Vector3(-1.0f, 1.0f, 0.0f));
            }
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            
            rb.AddForce(dirVector * 1000.0f, ForceMode2D.Impulse);
        }
    }

}
