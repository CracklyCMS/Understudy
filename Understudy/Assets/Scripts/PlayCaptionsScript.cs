using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayCaptionsScript : MonoBehaviour
{
    public GameManager gameManager;
    public MainstageTimer timer;
    public TextMeshProUGUI lineText;
    public string[] act1Lines;
    public string[] act2Lines;
    private string[] chosenLines;

    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (gameManager.actNumber == 1)
        {
            chosenLines = act1Lines;
        }
        else if (gameManager.actNumber == 2)
        {
            chosenLines = act2Lines;
        }
        lineText.text = chosenLines[index];
    }

    private void OnDisable()
    {
        if (index == chosenLines.Length)
        {
            gameObject.SetActive(false);
        }
        else
        {
            //index++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Submit"))
        {
            index++;
            if (index == chosenLines.Length)
            {
                timer.shouldFade = true;
                gameObject.SetActive(false);
            }
            if(index == 4 && gameManager.actNumber != 1)
            {
                timer.ActivateCue1();
                gameObject.SetActive(false);
            }
            if(index == 8 && gameManager.actNumber == 1)
            {
                timer.ActivateCue1();
                gameObject.SetActive(false);
            }
            if(index == 8 && gameManager.actNumber != 1)
            {
                timer.ActivateCue2();
                gameObject.SetActive(false);
            }
            if (index == 12 && gameManager.actNumber == 1)
            {
                timer.ActivateCue2();
                gameObject.SetActive(false);
            }
        }
        lineText.text = chosenLines[index];
    }

}
