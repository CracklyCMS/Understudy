using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb;
    Vector2 movement;
    public int faithfulness;
    public int timeOnStage;
    public bool inSpotlight;
    public bool canMove;

    Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        GameManager manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        faithfulness = manager.playerFaith;
        timeOnStage = manager.playerTimeOnStage;
        StartCoroutine(ManageFaithfulness());
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (canMove)
        {
            ManageMovement();
        }
        else
        {
            movement = Vector2.zero;
            float mx = 0;
            float my = 0;

            playerAnimator.SetFloat("iswalkingright", mx);
            playerAnimator.SetFloat("iswalkingforward", my);
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

        playerAnimator.SetFloat("iswalkingright", mx);
        playerAnimator.SetFloat("iswalkingforward", my);

        movement = new Vector2(mx, my).normalized;
    }

    private IEnumerator ManageFaithfulness()
    {
        yield return new WaitForSeconds(1);
        if (inSpotlight)
        {
            faithfulness++; //increment 1
        }
        if (SceneManager.GetActiveScene().name == "SpotlightAct" && canMove)
        {
            timeOnStage++;
        }
        StartCoroutine(ManageFaithfulness());
        //print(faithfulness);
    }
}
