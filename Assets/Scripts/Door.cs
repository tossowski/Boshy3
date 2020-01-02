using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;  

public class Door : MonoBehaviour
{

    public GameObject dDoor;
    private Animator anim;
    private Animator destanim;
    private GameObject player;
    private SpriteRenderer sp;
    private GameObject Ekey;
    private bool triggerStay;
    private bool fadeOutPlayer;
    private bool fadeInPlayer;
    private bool doneTransitioning;

    void Start()
    {
        Ekey = transform.Find("EKey").gameObject;
        Ekey.SetActive(false);
        player = GameObject.Find("Player");
        sp = player.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        destanim = dDoor.GetComponent<Animator>();
        fadeOutPlayer = false;
        fadeInPlayer = false;
        triggerStay = false;
        doneTransitioning = true;
    }

    void Update()
    {

        if (Input.GetKeyDown("e") && triggerStay && doneTransitioning)
        {
            doneTransitioning = false;
            fadeOutPlayer = true;
            player.GetComponent<PlayerController>().yeetPlayerMovement();
            Ekey.SetActive(false);
            anim.Play("DoorOpen", -1, 0.0f);
        }

        if (fadeOutPlayer)
        {
            Color prev = sp.color;
            prev.a -= 0.02f;
            if (prev.a < 0)
            {
                fadeOutPlayer = false;
            }

            Color32 color = prev;
            sp.color = color;
        }

        if (fadeInPlayer)
        {
            Color prev = sp.color;
            prev.a += 0.02f;
            if (prev.a > 1)
            {
                fadeInPlayer = false;
                anim.Play("DoorClose", -1, 0.0f);
            }

            Color32 color = prev;
            sp.color = color;
        }

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            triggerStay = true;
        }

        if (sp.color.a <= 0)
        {
            fadeInPlayer = true;
        }
        Ekey.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            triggerStay = false;
            Ekey.SetActive(false);
        }

    }

    public void setDoorOpen()
    {
        anim.SetBool("open", true);
        destanim.SetBool("open", true);
        GameObject.Find("VirtualCamera").GetComponent<CinemachineVirtualCamera>().PreviousStateIsValid = false;
        player.transform.position = dDoor.transform.position;
        Color prev = sp.color;
        prev.a = 0f;
        Color32 color = prev;
        sp.color = color;
    }

    public void setDoorClosed()
    { 
        anim.SetBool("open", false);
        destanim.SetBool("open", false);
        player.GetComponent<PlayerController>().resumePlayerMovement();
        doneTransitioning = true;
    }


}
