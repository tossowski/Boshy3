using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;  

public class Door : Interactable
{

    public GameObject dDoor;
    private Animator anim;
    private Image bossKeyImage;
    private DialogueManager dm;
    private Animator destanim;
    private SpriteRenderer sp;
    public bool unlocked;
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
        unlocked = false;
        doneTransitioning = true;
        bossKeyImage = GameObject.Find("Canvas").transform.Find("BossKeyIcon").gameObject.GetComponent<Image>();
        dm = GameObject.Find("Canvas").transform.Find("DialoguePanel").gameObject.GetComponent<DialogueManager>();
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

            if (unlocked)
            {
                doneTransitioning = false;
                fadeOutPlayer = true;
                player.GetComponent<PlayerController>().yeetPlayerMovement();
                anim.Play("DoorOpen", -1, 0.0f);
                return;
            }

            if (!dm.isActive() && bossKeyImage.color.a == 1.0f)
            {
                unlocked = true;
                dDoor.GetComponent<Door>().unlocked = true;
                List<string> text = new List<string>();
                text.Add("The key fits smoothly into the lock");
                dm.refreshText(text);
            } else if (!dm.isActive())
            {
                List<string> text = new List<string>();
                text.Add("Looks like you need a key");
                dm.refreshText(text);
            }
            
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
