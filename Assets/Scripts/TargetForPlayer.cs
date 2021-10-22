using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetForPlayer : MonoBehaviour
{
    [SerializeField]
    private float amountOfHp = 1f;

    [SerializeField]
    private Attributes hp = new Attributes(10);
    [SerializeField]
    private EnemyHitAnim anim;
    [SerializeField]
    private TargetManager manager;

    // Start is called before the first frame update
    void Start()
    {
        hp.SetNewValue(amountOfHp);
    }

    public void TakeDamage(float ouch)
    {
        hp.SubstractToAttrtibute(ouch);
        amountOfHp = hp.CurrentValue;

        if (hp.CurrentValue <= 0)
        {
            manager.TargetDestroyed();
            Destroy(gameObject);
        }
        anim.PlayEffect();
    }
}
