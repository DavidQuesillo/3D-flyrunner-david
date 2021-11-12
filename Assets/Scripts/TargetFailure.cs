using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFailure : MonoBehaviour
{
    public GameObject[] extraEnemies;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance.targetsDestroyed == false)
        {
            for (int i = 0; i < extraEnemies.Length; i++)
            {
                extraEnemies[i].SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
