using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpResetter : MonoBehaviour
{
    private PlayerController player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Attack")
        {
            player.setAirborneFalse();
            player.GetComponent<Rigidbody2D>().gravityScale = 40f;
        }
            
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Attack")
        {
            player.setAirborneTrue();
            player.GetComponent<Rigidbody2D>().gravityScale = 7f; ;
        }
        
    }
}
