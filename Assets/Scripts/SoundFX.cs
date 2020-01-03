using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Sound
{

    public class SoundFX : MonoBehaviour
    {
        private static AudioSource music;
        private static bool fadeOutMusic;
        private static bool fadeInMusic;
        private static float targetVolume;
        private static float dv;

        void Update()
        {
            if (fadeOutMusic)
            {
                if (music.volume > 0)
                {
                    music.volume -= dv;
                } else
                {
                    fadeOutMusic = false;
                    Destroy(music.gameObject);
                }
                
            }

            if (fadeInMusic)
            {
                if (music.volume < targetVolume)
                {
                    music.volume += dv;
                }
                else
                {
                    fadeInMusic = false;

                }

            }
        }


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
            fadeOutMusic = false;
            fadeInMusic = false;
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("AudioClip"))
            {
                if (g.GetComponent<AudioSource>().loop == true)
                {
                    Destroy(g);
                }
            }
        }

        public static void fadeMusicOut(float duration = 1.0f)
        {
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("AudioClip"))
            {
                if (g.GetComponent<AudioSource>().loop == true)
                {
                    music = g.GetComponent<AudioSource>();
                    dv = music.volume / duration * Time.deltaTime;
                    fadeOutMusic = true;
                }
            }
        }

        public static void fadeMusicIn(string name,  float v = 1f, float duration = 2.0f)
        {
            GameObject sound = Resources.Load("AudioClip") as GameObject;
            sound.GetComponent<AudioSource>().clip = Resources.Load(name) as AudioClip;
            sound.GetComponent<AudioSource>().volume = 0.0f;
            targetVolume = v;
            dv = targetVolume / duration * Time.deltaTime;
            GameObject clone = Instantiate(sound, Vector3.zero, Quaternion.identity) as GameObject;
            music = clone.GetComponent<AudioSource>();
            fadeInMusic = true;

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