using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightWaypointScript : MonoBehaviour
{
    public SpotlightScript spotlight;
    public float x;
    public float y;
    
    // Start is called before the first frame update
    void Start()
    {
        RandomTeleport();
    }

    // Update is called once per frame
    void Update()
    {
        if(spotlight.transform.position.x >= (x-1) && spotlight.transform.position.x <= (x+1))
        {
            print("WITHIN X RANGE");
            if (spotlight.transform.position.y >= (y - 1) && spotlight.transform.position.y <= (y + 1))
            {
                print("WITHING Y RANGE");
                RandomTeleport();
            }
        }
    }

    void RandomTeleport()
    {
        x = Random.Range(-11, 11);
        y = Random.Range(-3.25f, 3.75f);
        print(x);
        print(y);
        transform.position = new Vector3(x, y, 0);
    }
}
