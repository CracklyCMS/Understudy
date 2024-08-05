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
    public CameraScript gameCamera;
    public TextMeshProUGUI lineText;
    public TextMeshProUGUI controlsText;
    public Image leftChoice;
    public TextMeshProUGUI leftChoiceText;
    public Image rightChoice;
    public TextMeshProUGUI rightChoiceText;
    public Image dialogueBox;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI currentSpeaker;
    public Image currentSpeakerIcon;
    public MainstageTimer mainstageTimer;
    public PlayCaptionsScript playCaptions;
    public GameObject zeus;
    public string[] chosenDialogue;
    public string[] chosenOptions;
    public bool[] chosenIsPlayerTalking;
    public string chosenWhoName;
    public Sprite chosenWhoSprite;
    public Sprite prometheusSprite;


    private int dialogueIndex = 0;

    // Start is called before the first frame update
    public void SetParameters()
    {
        dialogueIndex = 0;
        leftChoiceText.text = chosenOptions[0];
        rightChoiceText.text = chosenOptions[1];
        dialogueText.text = chosenDialogue[dialogueIndex];
    }

    public void HandleCurrentSpeaker()
    {
        if ((dialogueIndex < chosenDialogue.Length))
        {
            if (chosenIsPlayerTalking[dialogueIndex])
            {
                currentSpeaker.text = "Prometheus";
                currentSpeakerIcon.sprite = prometheusSprite;
            }
            else
            {
                currentSpeaker.text = chosenWhoName;
                currentSpeakerIcon.sprite = chosenWhoSprite;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleCurrentSpeaker();
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetButtonDown("Cancel")) //RIGHT
        {
            rightChoice.color = new Color(0, 0.5f, 0.1f);
            leftChoice.color = new Color(0.5f, 0, 0);
            print("RIGHT CHOICE");
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)|| Input.GetButtonDown("Jump")) //LEFT
        {
            rightChoice.color = new Color(0.5f, 0, 0);
            leftChoice.color = new Color(0, 0.5f, 0.1f);
            print("LEFT CHOICE:");
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Submit"))
        {
            if(dialogueIndex < (chosenDialogue.Length - 2))
            {
                dialogueIndex++;
                print(dialogueIndex);
                dialogueText.text = chosenDialogue[dialogueIndex];
            }
            else if (dialogueIndex == (chosenDialogue.Length - 2))
            {
                dialogueIndex++;
                lineText.gameObject.SetActive(true);
                controlsText.gameObject.SetActive(true);
                leftChoice.gameObject.SetActive(true);
                rightChoice.gameObject.SetActive(true);
                dialogueBox.gameObject.SetActive(false);
                print(dialogueIndex);
            }
            else if (dialogueIndex == (chosenDialogue.Length - 1))
            {
                dialogueText.text = chosenDialogue[dialogueIndex];
                dialogueIndex++;
                lineText.gameObject.SetActive(false);
                controlsText.gameObject.SetActive(false);
                leftChoice.gameObject.SetActive(false);
                rightChoice.gameObject.SetActive(false);
                dialogueBox.gameObject.SetActive(true);
                print(dialogueIndex);
            }
            else
            {
                //RESETTING EVERYTHING
                zeus.SetActive(false);
                player.canMove = true;
                spotlight.gameObject.SetActive(true);
                playCaptions.gameObject.SetActive(true);
                leftChoice.color = new Color(0.5f, 0, 0);
                rightChoice.color = new Color(0.5f, 0, 0);
                mainstageTimer.timerIsRunning = true;
                gameCamera.shouldUpdate = true;
                gameCamera.GetComponent<Camera>().orthographicSize = 5;
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
