using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerScript player;
    public static GameManager Instance;

    private int playerFaith;
    public AnimatorController currentCostume;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene current, LoadSceneMode mode)
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
        player.GetComponent<Animator>().runtimeAnimatorController = currentCostume;
    }

    private void Update()
    {
        playerFaith = player.faithfulness;
    }
}
