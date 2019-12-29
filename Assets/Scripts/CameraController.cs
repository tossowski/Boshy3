using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private Camera cam;
    private Transform walls;
    private bool locked;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        cam = GetComponent<Camera>();
        locked = false;
        walls = transform.Find("Walls");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!locked)
        {
            float height = 2f * cam.orthographicSize;
            float width = height * cam.aspect;
            transform.position = new Vector3(Math.Max(player.transform.position.x, width / 2.096259f), player.transform.position.y, transform.position.z);
        }
        
    }

    public void unlock()
    {
        foreach (Transform child in walls)
        {
            child.gameObject.SetActive(false);
        }
        locked = false;

    }

    public void startEvent(GameObject e)
    {
        foreach (Transform child in walls)
        {
            child.gameObject.SetActive(true);
        }
        e.SetActive(true);
        locked = true;
    }
}
