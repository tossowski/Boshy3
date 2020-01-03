using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    private TextMeshProUGUI dialogue;
    private GameObject dialogueNext;
    private bool accelerate;
    private bool gonext;
    private bool drawingWords;
    private bool finished;

    // Start is called before the first frame update
    void Start()
    {
        dialogueNext = transform.Find("DialogueNext").gameObject;
        dialogueNext.SetActive(false);
        dialogue = transform.Find("DialogueText").gameObject.GetComponent<TextMeshProUGUI>();
        accelerate = false;
        gonext = false;
        drawingWords = false;
        finished = true;
        gameObject.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            gonext = true;
        } else
        {
            gonext = false;
        }

        if (Input.GetKey("e"))
        {
            accelerate = true;
        } else
        {
            accelerate = false;
        }
    }


    public void refreshText(List<string> newText)
    {
        gameObject.SetActive(true);
        StartCoroutine(drawText(newText));
        StartCoroutine(playDialogueSound());
    }

    IEnumerator playDialogueSound()
    {
        while (!finished)
        {
            if (drawingWords)
            {
                Sound.SoundFX.playSound("SoundFX/DialogueAmbient", false, 4 * GlobalSettings.Settings.soundfxVolume);
                yield return new WaitForSeconds(.05f);
            } else
            {
                yield return null;
            }
        }
        
    }

    IEnumerator drawText(List<string> newText)
    {
        finished = false;
        for (int i = 0; i < newText.Count; i++)
        {
            drawingWords = true;
            dialogue.text = "";
            foreach (char c in newText[i])
            {
                dialogue.text += c;
                
                if (accelerate)
                {
                    yield return new WaitForSeconds(.005f);
                }
                else
                {
                    yield return new WaitForSeconds(.05f);
                }
            }
            drawingWords = false;
            if (i != newText.Count - 1)
            {
                dialogueNext.SetActive(true);
            }
            while (!gonext)
            {
                yield return null;
            }

            if (i!= newText.Count - 1)
            {
                Sound.SoundFX.playSound("SoundFX/DialogueNext", false, GlobalSettings.Settings.soundfxVolume);
                yield return new WaitForSeconds(0.2f);
            }
            
            dialogueNext.SetActive(false);
        }

        finished = true;
        Sound.SoundFX.playSound("SoundFX/DialogueClose", false, 4 * GlobalSettings.Settings.soundfxVolume);
        GameObject.Find("Player").GetComponent<PlayerController>().resumePlayerMovement();
        gameObject.SetActive(false);
    }
    
}
