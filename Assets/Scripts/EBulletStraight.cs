using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBulletStraight : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private float speed = 5f;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb.AddForce(player.position - transform.position * speed, ForceMode.Impulse);

        Destroy(gameObject, 8f);
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<PlayerGlobal>()?.DamagePlayer()
    }*/
}
