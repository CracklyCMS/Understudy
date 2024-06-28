using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float x;
    public float y;
    public float leftXBound;
    public float rightXBound;
    public float downYBound;
    public float upYBound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x > leftXBound && player.position.x < rightXBound)
        {
            x = player.position.x;
        }
        if(player.position.y < upYBound && player.position.y > downYBound)
        {
            y = player.position.y;
        }
        transform.position = new Vector3(x + offset.x, y + offset.y, offset.z);
    }
}
