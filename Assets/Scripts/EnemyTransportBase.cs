using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTransportBase : MonoBehaviour
{
    [SerializeField]
    private float amountOfHp = 1f;
    [SerializeField]
    private bool destroyed;
    [SerializeField]
    private Attributes hp = new Attributes(10);
    
    [SerializeField]
    private EnemyHitAnim anim;

    private void Start()
    {
        hp.SetNewValue(amountOfHp);
    }
    public void TakeDamage(float ouch)
    {
        hp.SubstractToAttrtibute(ouch);
        amountOfHp = hp.CurrentValue;

        if (hp.CurrentValue <= 0)
        {
            DestroyTransport();
        }
        anim.PlayEffect();
    }

    public float GetHP()
    {
        return hp.CurrentValue;
    }

    private void DestroyTransport()
    {
        destroyed = true;

        //Destroy(gameObject);
    }

    public bool GetDestroyedStatus()
    {
        return destroyed;
    }
}
