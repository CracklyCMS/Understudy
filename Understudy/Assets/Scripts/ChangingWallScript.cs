using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingWallScript : MonoBehaviour
{

    public GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.outfitNumber != 2)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
