using System.Collections;
using TMPro;
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
    public GameObject movingProps;
    public MovingPropsScript prop1;
    public MovingPropsScript prop2;
    public MovingPropsScript prop3;
    public bool shouldFade = false;

    float fadeAlpha = 0;

    private void Start()
    {
        player.canMove = false;
        spotlight.gameObject.SetActive(false);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(StartMessage());
        //if (gameManager.actNumber == 2)
        //{
        //    movingProps.SetActive(true);
        //}
        //else
        //{
        //    movingProps.SetActive(false);
        //}
    }

    void Update()
    {
        if (shouldFade)
        {
            FadeOut();
        }
    }

    public void ActivateCue1()
    {
        lineCue1.transform.position = player.transform.position;
    }
    public void ActivateCue2()
    {
        lineCue2.transform.position = player.transform.position;
    }

    public void FadeOut()
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
                shouldFade = false;
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
        //time.gameObject.SetActive(true);
        //remaining.gameObject.SetActive(true);
        message.gameObject.SetActive(false);
        playCaptions.gameObject.SetActive(true);
    }
}
