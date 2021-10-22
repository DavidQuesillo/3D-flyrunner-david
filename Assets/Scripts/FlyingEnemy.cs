using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private float movePush = 1f;
    [SerializeField]
    private float waitTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForNextPush());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AdvanceThroughWorld()
    {
        rb.AddForce(new Vector3(Random.Range(-movePush / 2, movePush / 2), Random.Range(-movePush / 2, movePush / 2), movePush));
        StartCoroutine(WaitForNextPush());
    }

    IEnumerator WaitForNextPush()
    {
        yield return new WaitForSeconds(waitTime);
        AdvanceThroughWorld();
    }
}
