using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class KillZone : MonoBehaviour
{

    private GameObject player;
    private CinemachineVirtualCamera vcam;
    public GameObject respawnLoc;

    void Start()
    {
        player = GameObject.Find("Player");
        vcam = GameObject.Find("VirtualCamera").GetComponent<CinemachineVirtualCamera>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            vcam.PreviousStateIsValid = false;
            other.gameObject.transform.position = respawnLoc.transform.position;
            other.gameObject.GetComponent<HealthManager>().takeDamage(2);
        }
    }
}