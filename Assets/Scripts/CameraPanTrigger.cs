using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sound;
using Cinemachine;

public class CameraPanTrigger : MonoBehaviour
{

    private CinemachineVirtualCamera vcam;
    private CinemachineVirtualCamera targetCam;
    public GameObject target;

    public float duration;
    private bool entered;
    private bool ayeayea;
    // Start is called before the first frame update
    void Start()
    {
        entered = false;
        ayeayea = false;
        vcam = GameObject.Find("VirtualCamera").GetComponent<CinemachineVirtualCamera>();
        targetCam = target.GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (entered)
        {
            if (!ayeayea)
            {
                Sound.SoundFX.playSound("SoundFX/AYEAYYEYEYEYYAAYYAYAYAY", false, 0.4f);
                ayeayea = true;
            }
            if (duration > 0)
            {
                duration -= Time.deltaTime;
            } else
            {
                GameObject.Find("Player").GetComponent<PlayerController>().resumePlayerMovement();
                targetCam.m_Priority = 5;
                GameObject.Find("GreenSkeleton").GetComponent<Animator>().SetBool("fightStarted", true);
                Sound.SoundFX.playSound("Music/JojoLoop", true, 0.6f);
                Destroy(gameObject);
            }
            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("Player").GetComponent<PlayerController>().yeetPlayerMovement();
            Sound.SoundFX.stopAllMusic();
            entered = true;
            targetCam.m_Priority = 15;
        }
        
        
    }
}
