using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public string track;

    void Start()
    {
        Sound.SoundFX.playSound("Music/" + track, true, 0.4f);
    }

    public void transitionMusic(string t, float durationOut = 2.0f, float durationIn = 2.0f, float targetVolume = 1.0f)
    {
        StartCoroutine(ExampleCoroutine(t, durationOut, durationIn, targetVolume));
    }

    IEnumerator ExampleCoroutine(string t, float durationOut = 2.0f, float durationIn = 2.0f, float targetVolume = 1.0f)
    {
        //Print the time of when the function is first called.
        Sound.SoundFX.fadeMusicOut(durationOut);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds((int) durationOut + 1);

        //After we have waited 5 seconds print the time again.
        Sound.SoundFX.fadeMusicIn("Music/" + t, targetVolume, durationIn);
    }
}
