using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLinearShipMove : MonoBehaviour
{
    [SerializeField]
    private float targetHeight = 40f;
    [SerializeField]
    private float ascentSpeed = 1f;
    [SerializeField]
    private float advanceSpeed = 1f;
    [SerializeField]
    private bool heightReached;

    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private EnemyTransportBase etb;
    [SerializeField]
    private float fallDestroyTreshold = -50f;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(GoToHeight());
        MoveForward();
    }

    // Update is called once per frame
    void Update()
    {
        AscendToHeight();
        CheckDestroyed();
        //MoveForward();
    }

    private void AscendToHeight()
    {
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
