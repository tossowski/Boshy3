using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sound;
using Cinemachine;

public class CameraPanTrigger : MonoBehaviour
{

    protected CinemachineVirtualCamera vcam;
    private CinemachineVirtualCamera targetCam;
    private GameObject target;

    private float duration;
    private bool entered;
    private bool ayeayea;
    // Start is called before the first frame update
    public void Start()
    {
        target = GameObject.Find("GreenSkeletonCam");
        duration = 0;
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
            updateCutscene();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("Player").GetComponent<PlayerController>().yeetPlayerMovement();
            entered = true;
        }
    }

    public virtual void updateCutscene()
    {
        if (!ayeayea)
        {
            
            Sound.SoundFX.stopAllMusic();
            targetCam.m_Priority = 15;
            duration = Sound.SoundFX.playSound("SoundFX/AYEAYYEYEYEYYAAYYAYAYAY", false, 0.4f);
            ayeayea = true;
        }
        if (duration > 0)
        {
            duration -= Time.deltaTime;
        }
        else
        {
            GameObject.Find("Player").GetComponent<PlayerController>().resumePlayerMovement();
            targetCam.m_Priority = 5;
            GameObject.Find("GreenSkeleton").GetComponent<Animator>().SetBool("fightStarted", true);
            Sound.SoundFX.playSound("Music/JojoLoop", true, 0.6f);
            Destroy(gameObject);
        }

    }
}
