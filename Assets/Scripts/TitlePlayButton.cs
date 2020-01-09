using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlePlayButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void GoToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
        Time.timeScale = 1.0f;
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
        Time.timeScale = 1.0f;
    }

    public void GoToCastle()
    {
        SceneManager.LoadScene("Castle");
        Time.timeScale = 1.0f;
    }

    public void GoToTitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
        Time.timeScale = 1.0f;
    }
}
