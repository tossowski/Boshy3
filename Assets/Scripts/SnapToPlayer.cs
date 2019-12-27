using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SnapToPlayer : MonoBehaviour
{
    private GameObject player;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;
        transform.position = new Vector3(Math.Max(player.transform.position.x, width / 2.096259f), player.transform.position.y, transform.position.z);
    }
}
