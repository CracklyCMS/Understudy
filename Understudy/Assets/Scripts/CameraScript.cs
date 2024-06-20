using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float x;
    public float y;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x > -3.6 && player.position.x < 3.6)
        {
            x = player.position.x;
        }
        if(player.position.y < 2.5 && player.position.y > -2.5)
        {
            y = player.position.y;
        }
        transform.position = new Vector3(x + offset.x, y + offset.y, offset.z);
    }
}
