using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class ChangingRoomTriggerScript : MonoBehaviour
{
    public PlayerScript player;
    public Canvas changingRoomUI;
    public BackstageTimer backstageTimer;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        player.canMove = false;
        player.rb.velocity = Vector3.zero;
        changingRoomUI.gameObject.SetActive(true);
        backstageTimer.timerIsRunning = false;
        print("DETECTED");
    }
}
