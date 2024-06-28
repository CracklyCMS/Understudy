using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float moveSpeed;
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

    void ManageMovement()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) //RIGHT
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) //LEFT
        {
            transform.position += Vector3.right * -moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.DownArrow)) //DOWN
        {
            transform.position += Vector3.up * -moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) //UP
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        inSpotlight = true;
        print("DETECTED");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Spotlight")
        {
            inSpotlight = false;
            print("UNDETECTED");
        }
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
    }
}
