using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightScript : MonoBehaviour
{
    public Transform waypoint;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate direction to the player
        Vector2 direction = (waypoint.position - transform.position).normalized;

        // Move spotlight with constant speed
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }
}
