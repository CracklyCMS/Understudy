using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCueScript : MonoBehaviour
{
    public Camera gameCamera;
    public PlayerScript player;
    public SpotlightScript spotlight;
    public Canvas lines;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        player.canMove = false;
        spotlight.canMove = false;
        lines.gameObject.SetActive(true);
        gameCamera.orthographicSize = 3;
        print("DETECTED");
        Destroy(gameObject);
    }

}
