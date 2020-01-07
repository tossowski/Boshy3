using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DIOWarudo : MonoBehaviour
{

    private bool slowingTime;
    private float dv;
    private float duration;

    void Start()
    {
        AudioClip warudo = Resources.Load("SoundFX/ZAWARUDO") as AudioClip;
        duration = warudo.length;
        dv = 1.0f / duration * Time.deltaTime;
    }

    void Update()
    {
        if (slowingTime)
        {
            if (Time.timeScale > 0)
            {
                Time.timeScale = Math.Max(Time.timeScale - dv, 0.0f);
            } else
            {
                slowingTime = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Sound.SoundFX.stopAllMusic();
            Sound.SoundFX.playSound("SoundFX/ZAWARUDO", false, 2 * GlobalSettings.Settings.soundfxVolume);
            slowingTime = true;
            GetComponent<BoxCollider2D>().enabled = false;
        }

    }

    public void resumeTime()
    {
        Time.timeScale = 1f;
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
