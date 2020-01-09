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
    private GameObject menacing;

    private float duration;
    private bool entered;
    private bool ayeayea;
    private AudioClip JOJOLOOP;
    // Start is called before the first frame update
    public void Start()
    {
        target = GameObject.Find("GreenSkeletonCam");
        duration = 0;
        entered = false;
        ayeayea = false;
        vcam = GameObject.Find("VirtualCamera").GetComponent<CinemachineVirtualCamera>();
        menacing = GameObject.Find("Canvas").transform.Find("Menacing").gameObject;
        targetCam = target.GetComponent<CinemachineVirtualCamera>();
        JOJOLOOP = Resources.Load("Music/JojoLoop") as AudioClip;
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
            StartCoroutine(playJojoMusic(duration));
            ayeayea = true;
        }
    }


    IEnumerator playJojoMusic(float duration)
    {
        yield return new WaitForSeconds(1);
        menacing.SetActive(true);
        yield return new WaitForSeconds(duration - 1);
        menacing.SetActive(false);
        GameObject sound = Resources.Load("AudioClip") as GameObject;
        sound.GetComponent<AudioSource>().clip = JOJOLOOP;
        sound.GetComponent<AudioSource>().volume = 0.6f;
        var clone = Instantiate(sound, Vector3.zero, Quaternion.identity);
        GameObject.Find("Player").GetComponent<PlayerController>().resumePlayerMovement();
        targetCam.m_Priority = 5;
        GameObject.Find("GreenSkeleton").GetComponent<Animator>().SetBool("fightStarted", true);
        
        Destroy(gameObject);
    }
}
