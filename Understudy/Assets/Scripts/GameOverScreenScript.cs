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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.faithfulness <= 75)
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
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
