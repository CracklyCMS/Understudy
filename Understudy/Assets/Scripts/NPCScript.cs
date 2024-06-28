using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class NPCScript : MonoBehaviour
{

    public string dialogue;
    public TextMeshProUGUI text;
    public Canvas textBox;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        textBox.gameObject.SetActive(true);
        text.text = dialogue;
        print("DETECTED");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            textBox.gameObject.SetActive(false);
            print("UNDETECTED");
        }
    }



}
