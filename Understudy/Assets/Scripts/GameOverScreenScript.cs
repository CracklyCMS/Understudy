using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreenScript : MonoBehaviour
{
    public PlayerScript player;
    public TextMeshProUGUI winCondition;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.faithfulness <= 75)
        {
            winCondition.text = "You decided to stay off script by avoiding the spotlight and picking off script lines.";
        }
        else
        {
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
