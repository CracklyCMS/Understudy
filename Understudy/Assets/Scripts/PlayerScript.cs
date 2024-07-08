using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb;
    Vector2 movement;
    public int faithfulness;
    public bool inSpotlight;
    public bool canMove;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ManageFaithfulness());
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            ManageMovement();
        }
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            rb.velocity = movement * moveSpeed;
        }
    }

    void ManageMovement()
    {
        float mx = Input.GetAxisRaw("Horizontal");
        float my = Input.GetAxisRaw("Vertical");

        movement = new Vector2(mx, my).normalized;
    }

    private IEnumerator ManageFaithfulness()
    {
        yield return new WaitForSeconds(1);
        if (inSpotlight)
        {
            faithfulness++; //decrement 1
        }
        else
        {
            faithfulness--; //increment 1
        }
        StartCoroutine(ManageFaithfulness());
        print(faithfulness);
    }
}
