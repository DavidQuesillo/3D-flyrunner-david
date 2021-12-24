using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkCores : MonoBehaviour
{
    [SerializeField] private GameObject assignedBarrier;
    [SerializeField] private GameObject corelikeBarrier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        assignedBarrier.SetActive(false);
        corelikeBarrier.SetActive(true);
    }
}
