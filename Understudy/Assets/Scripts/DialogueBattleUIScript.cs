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
    public AudioClip goodApplause;
    public AudioClip badMurmur;


    private int dialogueIndex = 0;
    private bool isonScript;
    private bool optionChoosen = false;
    private AudioSource audio;

    // Start is called before the first frame update
    public void SetParameters()
    {
        dialogueIndex = 0;
        leftChoiceText.text = chosenOptions[0];
        rightChoiceText.text = chosenOptions[1];
        dialogueText.text = chosenDialogue[dialogueIndex];
        audio = GetComponent<AudioSource>();
        audio.volume = 0.5f;
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
            rightChoice.color = new Color(0.6f, 0.3f, 0.4f);
            leftChoice.color = new Color(0.5f, 0.1f, 0.5f);
            optionChoosen = true;
            isonScript = false;
            print("RIGHT CHOICE");
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)|| Input.GetButtonDown("Jump")) //LEFT
        {
            rightChoice.color = new Color(0.5f, 0.1f, 0.5f);
            leftChoice.color = new Color(0.6f, 0.3f, 0.4f);
            optionChoosen = true;
            isonScript = true;
            print("LEFT CHOICE");
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Submit"))
        {
            //PRE-CHOICE DIALOGUE
            if(dialogueIndex < (chosenDialogue.Length - 2))
            {
                dialogueIndex++;
                print(dialogueIndex);
                dialogueText.text = chosenDialogue[dialogueIndex];
            }
            //CHOOSING OPTION SCREEN
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
            //OPPONENT'S RESPONSE
            else if ((dialogueIndex == (chosenDialogue.Length - 1)) && optionChoosen)
            {
                if(isonScript) 
                {
                    audio.clip = goodApplause;
                    audio.Play();
                    player.faithfulness += 10;
                    print("FAITHFUL");
                }
                else
                {
                    audio.clip = badMurmur;
                    audio.Play();
                }
                dialogueText.text = chosenDialogue[dialogueIndex];
                dialogueIndex++;
                lineText.gameObject.SetActive(false);
                controlsText.gameObject.SetActive(false);
                leftChoice.gameObject.SetActive(false);
                rightChoice.gameObject.SetActive(false);
                dialogueBox.gameObject.SetActive(true);
                print(dialogueIndex);
            }
            //CLOSE
            else if((dialogueIndex == chosenDialogue.Length) && optionChoosen)
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
                isonScript = false;
                optionChoosen = false;
                gameObject.SetActive(false);
            }
        }
    }
}
