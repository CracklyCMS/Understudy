using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCueScript : MonoBehaviour
{
    public Camera gameCamera;
    public PlayerScript player;
    public SpotlightScript spotlight;
    public Canvas lines;
    public MainstageTimer mainstageTimer;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.canMove = false;
        player.rb.velocity = Vector3.zero;
        spotlight.canMove = false;
        lines.gameObject.SetActive(true);
        mainstageTimer.timerIsRunning = false;
        gameCamera.orthographicSize = 3;
        print("DETECTED");
        Destroy(gameObject);
    }

}
