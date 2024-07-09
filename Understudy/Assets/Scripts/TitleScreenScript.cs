using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Backstage");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
