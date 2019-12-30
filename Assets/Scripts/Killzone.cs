using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine; 

public class Killzone : MonoBehaviour
{
    public GameObject respawnLoc;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = respawnLoc.transform.position;
            Animator anim = other.gameObject.GetComponent<Animator>();
            GameObject.Find("VirtualCamera").GetComponent<CinemachineVirtualCamera>().PreviousStateIsValid = false;
        }
    }
}
