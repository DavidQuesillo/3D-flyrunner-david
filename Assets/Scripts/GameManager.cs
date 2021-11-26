using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerGlobal player;
    public Text targetsDisplay;
    public bool targetsDestroyed;

    private void Awake()
    {
        instance = this;
    }

    public void SwitchModes(bool groundToSky, int currentLevel, int levelToGo)
    {
        //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene.)
        if (groundToSky)
        {
            SceneManager.LoadSceneAsync(levelToGo);
            SceneManager.UnloadSceneAsync(currentLevel);
        }
        else
        {
            SceneManager.LoadSceneAsync(levelToGo);
            SceneManager.UnloadSceneAsync(currentLevel);
        }
    }

    public void TargetsGone()
    {
        targetsDestroyed = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(player);
        Cursor.lockState =  CursorLockMode.Confined;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
