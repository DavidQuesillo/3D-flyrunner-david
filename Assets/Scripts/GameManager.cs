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
    public SaveGame savedGame;

    private void Awake()
    {
        instance = this;

        savedGame = DataManager.LoadSave();
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
        savedGame.hp = 2f;
        DataManager.SaveData(savedGame);
    }

    public void Retry()
    {

    }

    public IEnumerator GameOver()
    {
        while (Time.timeScale > 0)
        {
            if ((Time.timeScale -= 0.1f) >= 0)
            {
                Time.timeScale -= 0.1f;
            }
            else
            {
                Time.timeScale = 0f;
            }

            /*if (Time.timeScale <= 0f)
            {

            }*/
            Debug.Log("slowing down");
            yield return new WaitForSecondsRealtime(0.1f);
        }
        Time.timeScale = 0;
        UiManager.instance.DisplayGameOver();
        player.enabled = false;
        Debug.Log("UI up");
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
