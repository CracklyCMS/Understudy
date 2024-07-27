using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerScript player;
    public static GameManager Instance;
    public CameraScript mainCamera;

    public int playerFaith;
    public int actNumber = 1;
    public int outfitNumber = 0;
    public RuntimeAnimatorController currentCostume;

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
        mainCamera = GameObject.Find("Main Camera").GetComponent<CameraScript>();
        player.GetComponent<Animator>().runtimeAnimatorController = currentCostume;
        if(SceneManager.GetActiveScene().name == "Backstage" && actNumber == 2)
        {
            player.transform.position = new Vector3(9, -5, 0);
            mainCamera.x = 4.916037f;
            mainCamera.y = -4.956565f;
        }
    }

    private void Update()
    {
        playerFaith = player.faithfulness;
    }
}
