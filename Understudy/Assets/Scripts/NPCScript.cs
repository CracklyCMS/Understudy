using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class NPCScript : MonoBehaviour
{

    public string defaultDialogue;
    public string act2Dialogue;
    public string diffOutfitDialogue;
    public string unchangedDialogue;
    public string npcName;
    public AudioSource soundSource;
    public AudioClip soundClip;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI text;
    public Canvas textBox;
    public Image iconComponent;
    public Sprite icon;
    public GameManager gameManager;

    private int actNumber;
    private int playerOutfitChoice;
    public bool activeNPC;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        soundSource = GetComponent<AudioSource>();
        actNumber = gameManager.actNumber;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        soundSource.pitch = 1.5f;
        soundSource.PlayOneShot(soundClip);
        activeNPC = true;
        textBox.gameObject.SetActive(true);
        iconComponent.sprite = icon;
        print("DETECTED");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            soundSource.pitch = .75f;
            soundSource.PlayOneShot(soundClip);
            activeNPC = false;
            textBox.gameObject.SetActive(false);
            print("UNDETECTED");
        }
    }

    private void Update()
    {
        if (activeNPC)
        {
            nameText.text = npcName;
            playerOutfitChoice = gameManager.outfitNumber;
            if (actNumber == 2)
            {
                text.text = act2Dialogue;
            }
            else if (playerOutfitChoice == 1)
            {
                text.text = diffOutfitDialogue;
            }
            else if (playerOutfitChoice == 2)
            {
                text.text = unchangedDialogue;
            }
            else
            {
                text.text = defaultDialogue;
            }
        }
    }

}
