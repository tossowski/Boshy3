using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;  

public class Door : Interactable
{

    public GameObject dDoor;
    private Animator anim;
    private Animator destanim;
    private SpriteRenderer sp;
    private bool fadeOutPlayer;
    private bool fadeInPlayer;
    private bool doneTransitioning;

    void Start()
    {
        base.Start();
        sp = player.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        destanim = dDoor.GetComponent<Animator>();
        fadeOutPlayer = false;
        fadeInPlayer = false;
        triggerStay = false;
        doneTransitioning = true;
    }

    public override void Update()
    {

        base.Update();

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

    public override void Interact()
    {
        if (doneTransitioning)
        {
            doneTransitioning = false;
            fadeOutPlayer = true;
            player.GetComponent<PlayerController>().yeetPlayerMovement();
            anim.Play("DoorOpen", -1, 0.0f);
        }
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (sp.color.a <= 0)
        {
            fadeInPlayer = true;
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
