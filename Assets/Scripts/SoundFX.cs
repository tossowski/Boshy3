using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Sound
{

    public class SoundFX : MonoBehaviour
    {
        public static void playSound(string name, bool repeat = true, float v = 1f)
        {
            GameObject sound = Resources.Load("AudioClip") as GameObject;
            sound.GetComponent<AudioSource>().clip = Resources.Load(name) as AudioClip;
            sound.GetComponent<AudioSource>().volume = v;
            var clone = Instantiate(sound, Vector3.zero, Quaternion.identity);
            if (!repeat)
            {
                clone.GetComponent<AudioSource>().loop = false;
                Destroy(clone, (int)(sound.GetComponent<AudioSource>().clip.length + 1));

            }
        }

        public static void stopAllMusic()
        {
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("AudioClip"))
            {
                if (g.GetComponent<AudioSource>().loop == true)
                {
                    Destroy(g);
                }
            }
        }

        public static void adjustMusicVolume(float target)
        {
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("AudioClip"))
            {
                if (g.GetComponent<AudioSource>().loop == true)
                {
                    g.GetComponent<AudioSource>().volume = target;
                }
            }
        }
    }
}