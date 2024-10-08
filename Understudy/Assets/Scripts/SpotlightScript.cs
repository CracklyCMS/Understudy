using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class SpotlightScript : MonoBehaviour
{
    public SpotlightWaypointScript waypoint;
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
            // Calculate direction to the waypoint
            Vector2 direction = (waypoint.transform.position - transform.position).normalized;

            if (!waypoint.inRange)
            {
                // Move spotlight with constant speed
                transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            player.inSpotlight = true;
            print("DETECTED");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player.GetComponent<SpriteRenderer>().color = new Color(.625f, .625f, .625f, 1f);
            player.inSpotlight = false;
            print("UNDETECTED");
        }
    }
}
