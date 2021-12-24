using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float amountOfHp = 1f;

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
            Destroy(gameObject);
        }
            anim?.PlayEffect();
    }

    public float GetHP()
    {
        return hp.CurrentValue;
    }
}
