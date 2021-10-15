using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float firingTimer = 1f;
    [SerializeField]
    private float fireRate = 0.2f;
    [SerializeField]
    private float fireRange = 100f;

    private float fireRateTimer = 0f;
    private float firingCountdown = 0f;

    private bool isInCooldown;
    private float cooldownTime = 1f;
    private bool playerInRange = false;
    
    [SerializeField]
    private Transform cannon;

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckRange();
        if (playerInRange)
        {
            LookAtPlayer();
            FireAtPlayer();
        }
    }

    void LookAtPlayer()
    {
        Vector3 directionToPlayer = (transform.position - player.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
        transform.rotation = Quaternion.Euler(transform.rotation.x, targetRotation.eulerAngles.y, transform.rotation.z);
    }

    void CheckRange()
    {
        //RaycastHit hit = Physics.Raycast(cannon.position, cannon.position - player.position, fireRange);
        Collider[] colliders = Physics.OverlapSphere(transform.position, fireRange);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].transform.GetInstanceID() == player.GetInstanceID())
            {
                RaycastHit hit;
                if (Physics.Raycast(cannon.position, player.position - cannon.position, out hit))
                {
                    playerInRange = true;
                }
                else
                {
                    playerInRange = false;
                }
            }
        }
    }

    void FireAtPlayer()
    {
            if (isInCooldown)
            {
                return;
            }

            Instantiate(bullet, cannon.position, cannon.rotation, null);
            StartCoroutine(BeginCooldown());
    }

    IEnumerator BeginCooldown()
    {
        isInCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isInCooldown = false;
    }
}
