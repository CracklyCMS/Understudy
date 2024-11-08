using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenScript : MonoBehaviour
{
    public Button start;

    public void StartGame()
    {
        SceneManager.LoadScene("IntroSequence");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
