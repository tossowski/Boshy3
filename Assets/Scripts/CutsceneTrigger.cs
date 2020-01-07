using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CutsceneTrigger : CameraPanTrigger
{
    private CinemachineVirtualCamera diocam;
    private DialogueManager dm;
    private bool cutscenestarted;

    void Start()
    {
        base.Start();
        cutscenestarted = false;
        diocam = GameObject.Find("DioCam").GetComponent<CinemachineVirtualCamera>();
        dm = GameObject.Find("Canvas").transform.Find("DialoguePanel").gameObject.GetComponent<DialogueManager>();
    }


    public override void updateCutscene()
    {
        if (!cutscenestarted)
        {
            StartCoroutine(handleCutscene());
            cutscenestarted = true;
        }
        
    }

    IEnumerator handleCutscene()
    {
        diocam.m_Priority = 15;
        List<string> text = new List<string>();
        text.Add("Oh? You're approaching me?");
        text.Add("Instead of running away, you're coming right to me?");
        dm.refreshText(text);
        while (dm.isActive())
        {
            yield return null;
        }
        diocam.m_Priority = 5;
        vcam.m_Lens.OrthographicSize = 5;
        text = new List<string>();
        text.Add("I can't beat the shit out of you without getting closer");
        dm.refreshText(text);
        while (dm.isActive())
        {
            yield return null;
        }
        diocam.m_Priority = 15;
        text = new List<string>();
        text.Add("Goodbye Jojo");
        dm.refreshText(text);
        while (dm.isActive())
        {
            yield return null;
        }
        diocam.m_Priority = 5;
        vcam.m_Lens.OrthographicSize = 15;
        GameObject.Find("Player").GetComponent<PlayerController>().resumePlayerMovement();
        Destroy(gameObject);
    }
}
