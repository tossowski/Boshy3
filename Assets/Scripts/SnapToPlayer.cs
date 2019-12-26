using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SnapToPlayer : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Math.Max(player.transform.position.x, -10.0f), player.transform.position.y, transform.position.z);
    }
}
