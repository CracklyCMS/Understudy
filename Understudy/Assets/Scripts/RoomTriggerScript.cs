using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomTriggerScript : MonoBehaviour
{

    public string scene;
    public Image fade;

    bool contactMade = false;
    float fadeAlpha = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        contactMade = true;
        print("DETECTED");
    }

    void Update()
    {
        if (contactMade)
        {
            if (fadeAlpha < 1)
            {
                fadeAlpha += .005f;
                fade.color = new Color(0, 0, 0, fadeAlpha);
            }
            else
            {
                SceneManager.LoadScene(scene);
            }
        }
    }
}
