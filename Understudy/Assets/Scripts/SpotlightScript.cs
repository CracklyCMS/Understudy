using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class SpotlightScript : MonoBehaviour
{
    public Transform waypoint;
    public PlayerScript player;
    public float moveSpeed;
    public bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            // Calculate direction to the player
            Vector2 direction = (waypoint.position - transform.position).normalized;

            // Move spotlight with constant speed
            transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player.inSpotlight = true;
            print("DETECTED");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player.inSpotlight = false;
            print("UNDETECTED");
        }
    }
}
