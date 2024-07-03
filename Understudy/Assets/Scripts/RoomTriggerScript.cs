using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;

public class RoomTriggerScript : MonoBehaviour
{

    public string scene;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(scene);
        print("DETECTED");
    }
}
