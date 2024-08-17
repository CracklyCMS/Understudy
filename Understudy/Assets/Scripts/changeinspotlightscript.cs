using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changeinspotlightscript : MonoBehaviour
{
    public SpriteRenderer player;
    public Color colorWhenInSpotlight;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Spotlight")
        {
            player.color = colorWhenInSpotlight;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Spotlight")
        {
            player.color = Color.white;
        }
    }
}
