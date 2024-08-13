using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCueScript : MonoBehaviour
{
    public CameraScript gameCamera;
    public PlayerScript player;
    public SpotlightScript spotlight;
    public DialogueBattleUIScript lines;
    public MainstageTimer mainstageTimer;
    public Canvas playCaptions;
    public GameManager gameManager;
    public GameObject opponent;
    public RuntimeAnimatorController zeusAnimator;
    public RuntimeAnimatorController hephAnimator;
    public string whoIsPlayerTalkingTo1;
    public Sprite whoIsPlayerTalkingToSprite1;
    public bool[] isPlayerTalking1;
    public string[] act1Dialogue;
    public string[] act1Options;
    public string whoIsPlayerTalkingTo2;
    public Sprite whoIsPlayerTalkingToSprite2;
    public bool[] isPlayerTalking2;
    public string[] act2Dialogue;
    public string[] act2Options;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ENABLE AND DISABLE SPECIFIC GAME OBJECTS
        opponent.SetActive(true);
        player.canMove = false;
        player.rb.velocity = Vector3.zero;
        player.transform.position = new Vector3(-2.25f, 0.5f, 0);
        spotlight.gameObject.SetActive(false);
        lines.gameObject.SetActive(true);
        playCaptions.gameObject.SetActive(false);
        mainstageTimer.timerIsRunning = false;
        gameCamera.shouldUpdate = false;
        gameCamera.GetComponent<Camera>().orthographicSize = 3;
        gameCamera.transform.position = new Vector3(0, 0, -10);
        //SET TEXT
        if (gameManager.actNumber == 1)
        {
            if(whoIsPlayerTalkingTo1 == "Hephaestus")
            {
                opponent.GetComponent<Animator>().runtimeAnimatorController = hephAnimator;
            }
            else
            {
                opponent.GetComponent<Animator>().runtimeAnimatorController = zeusAnimator;
            }
            lines.chosenDialogue = act1Dialogue;
            lines.chosenOptions = act1Options;
            lines.chosenIsPlayerTalking = isPlayerTalking1;
            lines.chosenWhoName = whoIsPlayerTalkingTo1;
            lines.chosenWhoSprite = whoIsPlayerTalkingToSprite1;
        }
        else if (gameManager.actNumber == 2)
        {
            lines.chosenDialogue = act2Dialogue;
            lines.chosenOptions = act2Options;
            lines.chosenIsPlayerTalking = isPlayerTalking2;
            lines.chosenWhoName = whoIsPlayerTalkingTo2;
            lines.chosenWhoSprite = whoIsPlayerTalkingToSprite2;
        }
        lines.SetParameters();
        print("DETECTED");
        Destroy(gameObject);
    }

}
