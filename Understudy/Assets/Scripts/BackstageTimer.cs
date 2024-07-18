using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackstageTimer : MonoBehaviour
{
    public float timeRemaining = 60;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;
    public string nextScene;
    public Image fade;

    float fadeAlpha = 0;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
        else if (timeRemaining == 0)
        {
            FadeOut();
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float seconds = Mathf.FloorToInt(timeToDisplay);

        timeText.text = seconds.ToString() + "s";
    }

    void FadeOut()
    {
        if(fadeAlpha < 1)
        {
            fadeAlpha += .005f;
            fade.color = new Color(0, 0, 0, fadeAlpha);
        }
        else
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
