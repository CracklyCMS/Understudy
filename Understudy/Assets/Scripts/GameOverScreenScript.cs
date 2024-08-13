using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreenScript : MonoBehaviour
{
    public PlayerScript player;
    public TextMeshProUGUI winCondition;
    public Image endScreen;
    public Sprite photoOff;
    public Sprite photoOn;
    public GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.faithfulness <= 30)
        {
            endScreen.sprite = photoOff;
            winCondition.text = "You decided to stay off script by avoiding the spotlight and picking off script lines.";
        }
        else
        {
            endScreen.sprite = photoOn;
            winCondition.text = "You decided to stay on script by following the spotlight and picking on script lines.";
        }
    }

    public void TitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
        manager.actNumber = 1;
        player.faithfulness = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
