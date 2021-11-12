using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLinearShipMove : MonoBehaviour
{
    [SerializeField]
    private float distanceFromPlayerToSpawn = 20f;
    private bool playerInRange = false;
    [SerializeField]
    private float targetHeight = 40f;
    [SerializeField]
    private float ascentSpeed = 1f;
    [SerializeField]
    private float advanceSpeed = 1f;
    [SerializeField]
    private bool heightReached;

    private Transform player;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private MeshRenderer mr;
    [SerializeField]
    private MeshCollider mc;
    [SerializeField]
    private EnemyTransportBase etb;
    [SerializeField]
    private float fallDestroyTreshold = -50f;
    private bool startedMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(GoToHeight());
        //MoveForward();
        player = GameManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDestroyed();
        if (playerInRange != true)
        {
            CheckPlayerDistance();
        }
        else
        {
            AscendToHeight();
            if (startedMoving == false)
            {
                MoveForward();
                startedMoving = true;
            }
        }
        //MoveForward();
    }

    private void AscendToHeight()
    {
        mr.enabled = true;
        mc.enabled = true;

        if (heightReached == false)
        {
            rb.MovePosition(Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, targetHeight, transform.position.z), ascentSpeed * (targetHeight - transform.position.y)));
        }
        if (transform.position.y >= targetHeight - 1)
        {
            heightReached = true;
        }
    }

    private void CheckDestroyed()
    {
        if (etb.GetDestroyedStatus())
        {
            rb.useGravity = true;
            if (transform.position.y <= fallDestroyTreshold)
            {
                Destroy(gameObject);
            }
        }
    }

    private void CheckPlayerDistance()
    {
        if (transform.position.z - player.position.z < distanceFromPlayerToSpawn)
        {
            playerInRange = true;
        }
    }

    private void MoveForward()
    {
        rb.AddForce(Vector3.forward * advanceSpeed, ForceMode.VelocityChange);
    }

    /*IEnumerator GoToHeight()
    {
        while (heightReached == false)
        {
            rb.MovePosition(Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, targetHeight, transform.position.z), ascentSpeed * targetHeight - transform.position.y));

            if (transform.position.y >= targetHeight)
            {
                heightReached = true;
                yield break;
            }
        }
    }*/
}
