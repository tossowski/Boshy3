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

    void OnCollisionEnter2D(Collision2D collision)
    {
        player.setAirborneFalse();
    }
}
