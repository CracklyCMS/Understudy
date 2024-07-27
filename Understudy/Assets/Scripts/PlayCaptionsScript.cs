using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayCaptionsScript : MonoBehaviour
{
    public GameManager gameManager;
    public MainstageTimer timer;
    public TextMeshProUGUI lineText;
    public string[] act1Lines;
    public string[] act2Lines;
    private string[] chosenLines;

    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (gameManager.actNumber == 1)
        {
            chosenLines = act1Lines;
        }
        else if (gameManager.actNumber == 2)
        {
            chosenLines = act2Lines;
        }
        lineText.text = chosenLines[index];
        //StartCoroutine(IncrementIndex());
    }

    private void OnEnable()
    {
        StartCoroutine(IncrementIndex());
    }

    // Update is called once per frame
    void Update()
    {
        if(timer.currentTime % 5 == 0)
        {
            if(index == chosenLines.Length)
            {
                gameObject.SetActive(false);
            }
            else
            {
                lineText.text = chosenLines[index];
            }
        }
    }

    public IEnumerator IncrementIndex()
    {
        yield return new WaitForSeconds(5);
        index++;
        StartCoroutine(IncrementIndex());
    }

    public void ForceIncrementIndex()
    {
        index++;
    }
}
