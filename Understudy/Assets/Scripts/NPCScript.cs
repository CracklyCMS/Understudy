using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class NPCScript : MonoBehaviour
{

    public string dialogue;
    public TextMeshProUGUI text;
    public Canvas textBox;
    public Image iconComponent;
    public Sprite icon;
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        textBox.gameObject.SetActive(true);
        text.text = dialogue;
        iconComponent.sprite = icon;
        print("DETECTED");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            textBox.gameObject.SetActive(false);
            print("UNDETECTED");
        }
    }



}
