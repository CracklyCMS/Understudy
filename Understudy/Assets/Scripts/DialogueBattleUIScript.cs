using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBattleUIScript : MonoBehaviour
{
    public PlayerScript player;
    public SpotlightScript spotlight;
    public Camera gameCamera;
    public TextMeshProUGUI lineText;
    public TextMeshProUGUI controlsText;
    public Image leftChoice;
    public TextMeshProUGUI leftChoiceText;
    public Image rightChoice;
    public TextMeshProUGUI rightChoiceText;
    public Image dialogueBox;
    public TextMeshProUGUI dialogueText;
    public MainstageTimer mainstageTimer;
    public PlayCaptionsScript playCaptions;
    public string[] chosenDialogue;
    public string[] chosenOptions;

    private int dialogueIndex = 0;

    // Start is called before the first frame update
    public void SetParameters()
    {
        dialogueIndex = 0;
        leftChoiceText.text = chosenOptions[0];
        rightChoiceText.text = chosenOptions[1];
        dialogueText.text = chosenDialogue[dialogueIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) //RIGHT
        {
            rightChoice.color = new Color(0, 0.5f, 0.1f);
            leftChoice.color = new Color(0.5f, 0, 0);
            print("RIGHT CHOICE");
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) //LEFT
        {
            rightChoice.color = new Color(0.5f, 0, 0);
            leftChoice.color = new Color(0, 0.5f, 0.1f);
            print("LEFT CHOICE:");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(dialogueIndex < (chosenDialogue.Length - 1))
            {
                dialogueIndex++;
                print(dialogueIndex);
                dialogueText.text = chosenDialogue[dialogueIndex];
            }
            else if (dialogueIndex == (chosenDialogue.Length - 1))
            {
                dialogueIndex++;
                lineText.gameObject.SetActive(true);
                controlsText.gameObject.SetActive(true);
                leftChoice.gameObject.SetActive(true);
                rightChoice.gameObject.SetActive(true);
                dialogueBox.gameObject.SetActive(false);
            }
            else
            {
                //RESETTING EVERYTHING
                player.canMove = true;
                spotlight.canMove = true;
                playCaptions.gameObject.SetActive(true);
                //playCaptions.ForceIncrementIndex();
                mainstageTimer.timerIsRunning = true;
                gameCamera.orthographicSize = 5;
                lineText.gameObject.SetActive(false);
                controlsText.gameObject.SetActive(false);
                leftChoice.gameObject.SetActive(false);
                rightChoice.gameObject.SetActive(false);
                dialogueBox.gameObject.SetActive(true);
                Array.Clear(chosenOptions, 0, chosenOptions.Length);
                Array.Clear(chosenDialogue, 0, chosenDialogue.Length);
                gameObject.SetActive(false);
            }
        }
    }
}
