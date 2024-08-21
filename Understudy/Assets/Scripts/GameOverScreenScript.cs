using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameOverScreenScript : MonoBehaviour
{
    public VideoClip onScriptCutscene;
    public VideoClip offScriptCutscene;
    public VideoPlayer cutscenePlayer;
    public GameObject cutsceneScreen;
    public PlayerScript player;
    public TextMeshProUGUI winCondition;
    public Image endScreen;
    public Sprite photoOff;
    public Sprite photoOn;
    public GameManager manager;

    private bool checkOnce = true;
    private bool hasCutsceneStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float trueFaithfulness = ((float)player.faithfulness / player.timeOnStage);
        if(trueFaithfulness <= .5 && checkOnce)
        {
            cutscenePlayer.clip = offScriptCutscene;
            endScreen.sprite = photoOff;
            winCondition.text = "You decided to stay off script by avoiding the spotlight and picking off script lines.";
            print(trueFaithfulness);
            checkOnce = false;
        }
        else if (checkOnce)
        {
            cutscenePlayer.clip = onScriptCutscene;
            endScreen.sprite = photoOn;
            winCondition.text = "You decided to stay on script by following the spotlight and picking on script lines.";
            print(trueFaithfulness);
            checkOnce = false;
        }
        if (cutscenePlayer.isPlaying && hasCutsceneStarted != true)
        {
            print("has Started");
            hasCutsceneStarted = true;
        }
        else if (!cutscenePlayer.isPlaying && hasCutsceneStarted == true)
        {
            print("screen Destroyed");
            Destroy(cutsceneScreen);
            hasCutsceneStarted = false;
        }
    }

    public void TitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
        manager.actNumber = 1;
        player.faithfulness = 0;
        player.timeOnStage = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
