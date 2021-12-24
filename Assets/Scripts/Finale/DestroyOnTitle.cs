using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTitle : MonoBehaviour
{
    void Update()
    {
        if (GameManager.instance.currentState == EGameStates.Title)
        {
            Destroy(gameObject);
        }
    }
}
