using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBumper : MonoBehaviour
{
    [SerializeField] private float speed = 1f;   
    [SerializeField] private float range = 10f;
    [SerializeField] private float bumpPower = 10f;
    [SerializeField] private bool playerInRange;


    private Vector3 search;
    [SerializeField] private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        search = new Vector3(range, 0.1f, range);
    }

    // Update is called once per frame
    void Update()
    {
        //CheckRange();
        if (playerInRange)
        {
            ChasePlayer();
        }
    }

    /*private void CheckRange()
    {
        Collider[] box = Physics.OverlapBox(transform.position, search);
        for (int i = 0; i < box.Length; i++)
        {
            if (box[i].CompareTag("Player"))
            {
                playerInRange = true;
            }
        }

        if (GameManager.instance.player.transform.position.x - transform.position.x < search.x && GameManager.instance.player.transform.position.z - transform.position.z < search.z)
        {
            playerInRange = false;
        }
    }*/

    private void ChasePlayer()
    {
        rb.AddForce((GameManager.instance.player.transform.position - transform.position).normalized * speed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce((GameManager.instance.player.transform.position - transform.position).normalized * bumpPower, ForceMode.VelocityChange);
        }
    }
}
