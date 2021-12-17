using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPlaythrough : MonoBehaviour
{
    [SerializeField] private SaveGame blankSave;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame()
    {
        /*blankSave.hp = 100f;
        blankSave.level = 1;
        blankSave.isFlying = false;*/
        
        DataManager.SaveData(blankSave);

        
        SceneManager.LoadSceneAsync(0);
        SceneManager.LoadSceneAsync(2);
    }
}
