using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sound;

namespace GlobalSettings
{
    public class Settings : MonoBehaviour
    {
        public GameObject fxSliderGameObject;
        public GameObject musicSliderGameObject;

        private Slider fxSlider;
        private Slider musicSlider;
        public static float soundfxVolume;
        public static float musicVolume;

        void Start()
        {
            fxSlider = fxSliderGameObject.GetComponent<Slider>();
            musicSlider = musicSliderGameObject.GetComponent<Slider>();
            soundfxVolume = 1.0f;
            musicVolume = 0.4f;
        }

        void Update()
        {
            soundfxVolume = fxSlider.value;
            Sound.SoundFX.adjustMusicVolume(musicSlider.value);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1.0f;
                GameObject.FindWithTag("Player").GetComponent<PlayerController>().UIOpen = false;
                gameObject.SetActive(false);
            }
        }

        
    }
}

