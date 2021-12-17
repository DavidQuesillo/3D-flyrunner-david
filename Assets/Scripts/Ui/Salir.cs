using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salir : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Closing app");
    }
}
