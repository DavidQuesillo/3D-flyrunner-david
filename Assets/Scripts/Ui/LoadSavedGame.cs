using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSavedGame : MonoBehaviour
{
    [SerializeField] private SaveGame loadedSave;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGame()
    {
        loadedSave = DataManager.LoadSave();
        SceneManager.LoadSceneAsync(0);
        SceneManager.LoadSceneAsync(loadedSave.level);
    }
}
