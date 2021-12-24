using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialRetrievePrompt : MonoBehaviour
{
    [SerializeField] private TutorialTargets tt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnDestroy()
    {
        tt.RetrieveTargets();
    }*/

    private void OnDisable()
    {
        tt.RetrieveTargets();
    }
}
