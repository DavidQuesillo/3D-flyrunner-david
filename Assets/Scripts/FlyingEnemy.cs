using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField] private float movePush = 1f;
    [SerializeField] private float waitTime = 1f;
    [SerializeField] private float preferredDistance = 20f;
    private bool chaseStarted = false;
    private EnemyTurret et;

    // Start is called before the first frame update
    void Start()
    {
        et = GetComponent<EnemyTurret>();
        //StartCoroutine(WaitForNextPush());
    }

    // Update is called once per frame
    void Update()
    {
        if (et.playerInRange == true && chaseStarted == false)
        {
            StartCoroutine(WaitForNextPush());
            chaseStarted = true;
        }
    }

    void AdvanceThroughWorld()
    {
        if (transform.position.z - GameManager.instance.player.transform.position.z < preferredDistance)
        {
            rb.AddForce(new Vector3(Random.Range(-movePush / 2, movePush / 2), Random.Range(-movePush / 2, movePush / 2), movePush));
        }
        else
        {
            rb.AddForce(new Vector3(Random.Range(-movePush / 2, movePush / 2), Random.Range(-movePush / 2, movePush / 2), movePush));
        }
        
        StartCoroutine(WaitForNextPush());
        Debug.Log("Moving");
    }

    IEnumerator WaitForNextPush()
    {

            yield return new WaitForSeconds(waitTime);
            AdvanceThroughWorld();
        
    }
}
