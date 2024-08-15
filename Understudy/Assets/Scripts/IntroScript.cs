using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Introscript : MonoBehaviour
{
    public TMP_Text displayText;
    public string[] textOptions; // An array of different text strings
    private int currentIndex = 0;

    bool timerReached = true;
    float timer = 0;
    int lineCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        displayText.text = textOptions[currentIndex];
    }


    // Update is called once per frame
    void Update()
    {
        bool spacePressed = Input.GetKey(KeyCode.Space);
        if (spacePressed && timerReached)
        {
            // Cycle through text options
            currentIndex = (currentIndex + 1) % textOptions.Length;
            displayText.text = textOptions[currentIndex];
            timerReached = false;
            lineCount += 1;
        }

        if (!timerReached && timer < 2)
        {
            timer += Time.deltaTime;
        }
        if (!timerReached && timer >= 2)
        {
            timerReached = true;
            timer = 0;
        }

        if (lineCount == textOptions.Length - 1){
            SceneManager.LoadScene("Backstage");
        }

    }
}