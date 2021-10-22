using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyTeleport : MonoBehaviour
{
    [SerializeField]
    private bool goingToSky;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = Vector3.zero;
            other.GetComponent<PlayerGlobal>().SwitchStates(goingToSky);
            GameManager.instance.SwitchModes(goingToSky);
        }
    }
}
