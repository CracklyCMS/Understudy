using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float moveSpeed;
    public int anxiety;
    public bool inSpotlight;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ManageAnxiety());
    }

    // Update is called once per frame
    void Update()
    {
        ManageMovement();
    }

    void ManageMovement()
    {
        if (Input.GetKey(KeyCode.D)) //RIGHT
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A)) //LEFT
        {
            transform.position += Vector3.right * -moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S)) //DOWN
        {
            transform.position += Vector3.up * -moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W)) //UP
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

    private IEnumerator ManageAnxiety()
    {
        yield return new WaitForSeconds(1);
        if (inSpotlight)
        {
            anxiety--; //decrement 1
        }
        else
        {
            anxiety++; //increment 1
        }
        StartCoroutine(ManageAnxiety());
    }
}
