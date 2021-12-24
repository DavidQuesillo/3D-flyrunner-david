using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTargets : MonoBehaviour
{
    [SerializeField] private GameObject[] cores = new GameObject[6];
    [SerializeField] private GameObject retrieveFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RetrieveTargets()
    {
        for (int i = 0; i < cores.Length; i++)
        {
            cores[i].SetActive(false);
            Instantiate(retrieveFX, cores[i].transform.position, Quaternion.identity, null);
        }
    }
}
