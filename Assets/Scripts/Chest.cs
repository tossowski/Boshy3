using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sound;

public class Chest : Interactable
{

    private Animator anim;
    private bool looted;
    private DialogueManager dm;
    public List<string> text;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
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
    }

    public override void Interact()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().yeetPlayerMovement();
        anim.Play("ChestOpen", -1, 0.0f);
        Sound.SoundFX.playSound("SoundFX/ChestOpen", false, GlobalSettings.Settings.soundfxVolume);
        looted = true;
        Ekey.SetActive(false);
        GetComponent<BoxCollider2D>().enabled = false;
        dm.refreshText(text);
    }
}
