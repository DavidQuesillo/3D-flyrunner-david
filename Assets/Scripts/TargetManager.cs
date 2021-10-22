using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [SerializeField]
    private int targetAmount = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TargetDestroyed()
    {
        targetAmount -= 1;
        if (targetAmount <= 0)
        {
            GameManager.instance.TargetsGone();
        }
    }
}
