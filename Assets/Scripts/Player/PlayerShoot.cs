using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private float range = 1000f;
    [SerializeField]
    private float damage = 2f;

    /*[SerializeField]
    private float initialFireRate = 0.1f;
    private float fireRate = 0.1f;
    [SerializeField]
    private float shootPower = 5f;

    [SerializeField]
    private GameObject bulletPrefab;*/
    
    public Transform cam;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        //fireRate = initialFireRate;
    }

    // Update is called once per frame
    void Update()
    {
        SingleShot();
    }

    void SingleShot()
    {
        //fireRate -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                if (hit.transform.CompareTag("Enemy"))
                {
                    hit.transform.GetComponent<EnemyHealth>().TakeDamage(damage);
                }
                if (hit.transform.CompareTag("PlayerTarget"))
                {
                    hit.transform.GetComponent<TargetForPlayer>().TakeDamage(damage);
                }
                if (hit.transform.CompareTag("EnemyTransport"))
                {
                    hit.transform.GetComponent<EnemyTransportBase>().TakeDamage(damage);
                }
                /*else if (hit.transform.CompareTag("EnemyBullet"))
                {
                    if (hit.transform.GetComponent<EBulletHoming>() != null)
                    {
                        hit.transform.GetComponent<EBulletHoming>().DamageProjectile(damage);
                    }
                }*/
            }
        }

        /*if (Input.GetMouseButton(1))
        {
            if (fireRate <= 0)
            {
                GameObject shot = Instantiate(bulletPrefab, transform.position, transform.rotation, null);
                shot.GetComponent<Rigidbody>().AddForce(cam.forward * shootPower, ForceMode.Impulse);
                fireRate = initialFireRate;
            }
        }*/
    }
}
