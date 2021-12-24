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
    [SerializeField] private AudioSource aus;
    [SerializeField] private Animator canonAnim;
    [SerializeField] private AudioClip shootClip;
    /*[SerializeField] private AudioClip hitClip;
    [SerializeField] private AudioClip noDamageClip;
    [SerializeField] private AudioClip missClip;*/
    [SerializeField] private GameObject hitDamageEffect;
    [SerializeField] private GameObject hitNoDamageEffect;
    [SerializeField] private GameObject missEffect;
    [SerializeField] private GameObject firingEffect;
    [SerializeField] private Transform canonTip;


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
            aus.PlayOneShot(shootClip);
            canonAnim.SetTrigger("fire");
            Instantiate(firingEffect, canonTip);
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                if (hit.transform.CompareTag("Enemy"))
                {
                    hit.transform.GetComponent<EnemyHealth>().TakeDamage(damage);
                    Instantiate(hitDamageEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    //aus.PlayOneShot(hitClip);
                    //Debug.Log("hit an enemy");
                }
                else if (hit.transform.CompareTag("PlayerTarget"))
                {
                    hit.transform.GetComponent<TargetForPlayer>().TakeDamage(damage);
                    Instantiate(hitDamageEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    //aus.PlayOneShot(hitClip);
                }
                else if (hit.transform.CompareTag("Invincible"))
                {
                    Instantiate(hitNoDamageEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    //aus.PlayOneShot(noDamageClip);
                }
                /*if (hit.transform.CompareTag("EnemyTransport"))
                {
                    hit.transform.GetComponent<EnemyTransportBase>().TakeDamage(damage);
                }*/
                else
                {
                    Instantiate(missEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    //aus.PlayOneShot(missClip);
                    //Debug.Log("hit a wall");
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
