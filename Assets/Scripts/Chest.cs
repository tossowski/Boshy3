using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sound;

public class Chest : Interactable
{

    private Animator anim;
    private bool looted;
    private DialogueManager dm;
    public List<string> text;
    private GameObject item;
    private bool movingItem;


    void Start()
    {
        base.Start();
        item = transform.Find("Item").gameObject;
        movingItem = false;
        anim = GetComponent<Animator>();
        looted = false;
        dm = GameObject.Find("Canvas").transform.Find("DialoguePanel").gameObject.GetComponent<DialogueManager>();
    }

    public override void Update()
    {
        if (!looted)
        {
            base.Update();
        }

        if (movingItem)
        {
            item.transform.Translate(8 * new Vector3(0.0f, 1.0f, 0.0f) * Time.deltaTime);
        }
    }

    public override void Interact()
    {

        GameObject.Find("Player").GetComponent<PlayerController>().yeetPlayerMovement();
        anim.Play("ChestOpen", -1, 0.0f);
        Sound.SoundFX.playSound("SoundFX/ChestOpen", false, GlobalSettings.Settings.soundfxVolume);
        looted = true;
        Ekey.SetActive(false);
        GetComponent<BoxCollider2D>().enabled = false;
        item.SetActive(true);
        movingItem = true;
    }

    void startDialogue()
    {
        Image image = GameObject.Find("Canvas").transform.Find("BossKeyIcon").gameObject.GetComponent<Image>();
        Color prev = image.color;
        prev.a = 1.0f;
        image.color = prev;

        dm.refreshText(text, item.GetComponent<Item>());
        
        movingItem = false;
    }
}
