using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainstageTimer : MonoBehaviour
{
    public float timeRemaining = 90;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;
    public string nextScene;
    public Image fade;
    public PlayerScript player;
    public LineCueScript lineCue1;
    public LineCueScript lineCue2;
    public SpotlightScript spotlight;
    public TextMeshProUGUI orNot;
    public TextMeshProUGUI time;
    public TextMeshProUGUI remaining;
    public Canvas message;
    public GameOverScreenScript gameOverScreen;
    public GameManager gameManager;
    public float currentTime;
    public Canvas playCaptions;

    float fadeAlpha = 0;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = false;
        player.canMove = false;
        spotlight.gameObject.SetActive(false);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(StartMessage());
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

        currentTime = seconds;

        if(seconds == 60)
        {
            lineCue1.transform.position = player.transform.position;
        }
        if(seconds == 30)
        {
            print("LINE CUE 2");
            lineCue2.transform.position = player.transform.position;
        }

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
            if(gameManager.actNumber == 1)
            {
                gameManager.actNumber = 2;
                SceneManager.LoadScene(nextScene);
            }
            else if(gameManager.actNumber == 2)
            {
                gameOverScreen.gameObject.SetActive(true);
            }
        }
    }

    private IEnumerator StartMessage()
    {
        yield return new WaitForSeconds(2);
        orNot.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        timerIsRunning = true;
        player.canMove = true;
        spotlight.gameObject.SetActive(true);
        time.gameObject.SetActive(true);
        remaining.gameObject.SetActive(true);
        message.gameObject.SetActive(false);
        playCaptions.gameObject.SetActive(true);
    }
}
