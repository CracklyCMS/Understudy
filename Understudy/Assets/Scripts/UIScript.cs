using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public PlayerScript player;
    public SpotlightScript spotlight;
    public Camera gameCamera;
    public Image leftChoice;
    public Image rightChoice;

    // Start is called before the first frame update
    void Start()
    {
        
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
        if (Input.GetKey(KeyCode.Space))
        {
            player.canMove = true;
            spotlight.canMove = true;
            gameObject.SetActive(false);
            gameCamera.orthographicSize = 5;
        }
    }
}
