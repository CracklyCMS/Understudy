using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class ChangingRoomUIScript : MonoBehaviour
{
    public Image currentOutfit;
    public PlayerScript player;
    public BackstageTimer backstageTimer;

    public Sprite[] outfitSprites;
    public AnimatorController[] outfitAnims;

    GameManager gameManager;
    int outfitIndex = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        currentOutfit.sprite = outfitSprites[outfitIndex];

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) //RIGHT
        {
            currentOutfit.sprite = outfitSprites[outfitIndex];
            outfitIndex++;
            if (outfitIndex == 2)
            {
                outfitIndex = 0;
            }
            print(outfitIndex);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //outfitIndex++;
            //if(outfitIndex == 2)
            //{
                //outfitIndex = 0;
            //}
            gameManager.currentCostume = outfitAnims[outfitIndex];
            player.GetComponent<Animator>().runtimeAnimatorController = outfitAnims[outfitIndex];
            player.canMove = true;
            gameObject.SetActive(false);
            backstageTimer.timerIsRunning = true;
            outfitIndex = 0;
            currentOutfit.sprite = outfitSprites[outfitIndex];
        }
    }
}
