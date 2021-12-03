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
    [SerializeField] private PlayerShoot ps;
    [SerializeField] private GameObject deathExplosion;
    private CapsuleCollider cs;

    Vector2 rotation = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        cs = GetComponent<CapsuleCollider>();
        hp.SetNewValue(100f);
        hp.SetCurrentValue(health);
        UiManager.instance.UpdateUiHP(hp.CurrentValue);
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
        //Destroy(gameObject);
        StartCoroutine(GameManager.instance.GameOver());
        cs.enabled = false;
        ps.enabled = false;
        Debug.Log("player dies");
    }

    public void DamagePlayer(float ouch)
    {
        hp.SubstractToAttrtibute(ouch);
        health = hp.CurrentValue;
        UiManager.instance.UpdateUiHP(hp.CurrentValue);
        if (hp.CurrentValue <= 0)
        {
            PlayerDeath();
        }
    }
    public void HealPlayer(float heal)
    {
        //Debug.Log("healed?" + heal);
        hp.AddToAttribute(heal);
        health = hp.CurrentValue;
        UiManager.instance.UpdateUiHP(hp.CurrentValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.transform.CompareTag("EnemyBullet"))
        {
            DamagePlayer(other.transform.GetComponent<EnemyBulletBase>().GetDamage());
            health = hp.CurrentValue;
            Destroy(other.gameObject);
            if (hp.CurrentValue <= 0)
            {
                PlayerDeath();
            }
        }*/
        if (other.transform.CompareTag("Crash"))
        {
            DamagePlayer(2f);
        }
        /*if (other.CompareTag("HpDrop"))
        {
            HealPlayer(other.GetComponent<HpDrops>().getHealAmount());
            health = hp.CurrentValue;
            Destroy(other.gameObject);
            Debug.Log("healed?");
        }*/
        other.GetComponent<DropsBase>()?.ConsumeDrop();
    }
}
