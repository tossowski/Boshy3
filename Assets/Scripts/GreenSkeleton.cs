using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSkeleton : Skeleton
{

    private float timer;
    private bool jittering;
    private Vector3 pos;

    public override void Update()
    {
        if (anim.GetBool("fightStarted"))
        {
            base.Update();
        }

        if (timer > 0)
        {
            timer -= 0.01f;
        }

        if (jittering)
        {
            transform.position = new Vector2(pos.x, pos.y) + Random.insideUnitCircle;
        }
    }

    public override void deathrattle()
    {
        
        GameObject.Find("MusicManager").GetComponent<MusicManager>().transitionMusic("TwilightRealm");
        base.deathrattle();
    }

    void startDeathSequence()
    {
        StartCoroutine(deathSequence());
    }

    IEnumerator deathSequence()
    {
        player.GetComponent<PlayerController>().UIOpen = true;
        pos = transform.position;
        anim.enabled = false;
        Sound.SoundFX.stopAllMusic();
        Time.timeScale = 0.0f;
        Sound.SoundFX.playSound("SoundFX/NANI", false, 1.0f);
        timer = 0.5f;
        while (timer > 0)
        {
            yield return null;
        }
        Time.timeScale = 1.0f;
        jittering = true;

        player.GetComponent<PlayerController>().getRigidBody().velocity = Vector2.zero;
        float length = Sound.SoundFX.playSound("SoundFX/ORAORAORA", false, 1.0f);
        player.GetComponent<PlayerController>().getAnimator().Play("ORAORAORA", -1, 0.0f);
        timer = length / 3;
        while (timer > 0)
        {
            yield return null;
        }
        anim.enabled = true;
        jittering = false;
        player.GetComponent<PlayerController>().resumePlayerMovement();
        player.GetComponent<PlayerController>().getAnimator().Play("KnightIdle", -1, 0.0f);
        player.GetComponent<PlayerController>().UIOpen = false;
    }
}
