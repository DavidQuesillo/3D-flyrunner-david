using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGlobal : MonoBehaviour
{
    [SerializeField]
    private Attributes hp = new Attributes(10);

    [SerializeField]
    private float health = 10f;
    [SerializeField]
    private bool isFlying;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private PlayerMovement pm;
    [SerializeField]
    private PlayerRunning pr;

    Vector2 rotation = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        hp.SetNewValue(health);
    }

    // Update is called once per frame
    void Update()
    {
        AimShooting();
    }

    public void SwitchStates(bool areWeFlying)
    {
        isFlying = areWeFlying;
        
        if (isFlying == true)
        {
            pm.enabled = true;
            pr.enabled = false;
            rb.useGravity = false;
            
        }
        else
        {
            pm.enabled = false;
            pr.enabled = true;
            rb.useGravity = true;
        }
    }

    void AimShooting()
    {
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        //Mathf.Clamp(rotation.x, -90f, 90f);
        if (rotation.x <= -90)
        {
            rotation.x = -90;
        }
        if (rotation.x >= 90)
        {
            rotation.x = 90;
        }
        transform.eulerAngles = rotation;
    }

    public void PlayerDeath()
    {
        Destroy(gameObject);
    }

    public void DamagePlayer(float ouch)
    {
        hp.SubstractToAttrtibute(ouch);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("EnemyBullet"))
        {
            DamagePlayer(other.transform.GetComponent<EnemyBulletBase>().GetDamage());
            health = hp.CurrentValue;
            Destroy(other.gameObject);
            if (hp.CurrentValue <= 0)
            {
                PlayerDeath();
            }
        }
    }
}
