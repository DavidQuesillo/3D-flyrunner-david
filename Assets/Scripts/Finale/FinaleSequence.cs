using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinaleSequence : MonoBehaviour
{
    [SerializeField] private bool titleAble = false;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.ChangeGameState(EGameStates.Title);
    }

    // Update is called once per frame
    void Update()
    {
        if (titleAble)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void EnableReturningToTitle()
    {
        titleAble = true;
    }
}
