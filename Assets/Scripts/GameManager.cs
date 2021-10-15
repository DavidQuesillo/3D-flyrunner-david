using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    private GameObject player;

    private void Awake()
    {
        instance = this;
    }

    public void SwitchModes()
    {
        //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene.)

        SceneManager.LoadSceneAsync(2);
        SceneManager.UnloadSceneAsync(1);
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(player);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
