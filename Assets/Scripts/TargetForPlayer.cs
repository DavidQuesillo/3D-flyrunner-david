using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetForPlayer : MonoBehaviour
{
    [SerializeField]
    private float amountOfHp = 1f;
    private float startHp;
    [SerializeField] private int dropAmount = 5;
    [SerializeField] private float dropsExplosionForce = 1f;

    [SerializeField]
    private Attributes hp = new Attributes(10);
    [SerializeField] private GameObject hpDrop;
    [SerializeField]
    private EnemyHitAnim anim;
    [SerializeField]
    private TargetManager manager;

    // Start is called before the first frame update
    void Start()
    {
        hp.SetNewValue(amountOfHp);
        startHp = amountOfHp;
    }

    public void TakeDamage(float ouch)
    {
        hp.SubstractToAttrtibute(ouch);
        amountOfHp = hp.CurrentValue;

        if (hp.CurrentValue <= 0)
        {
            manager.TargetDestroyed();
            DropHP();
            gameObject.SetActive(false);
        }
        anim.PlayEffect();
    }
    public void ResetHealth()
    {
        hp.SetNewValue(startHp);
    }
    private void DropHP()
    {
        for (int i = 0; i < dropAmount; i++)
        {
            GameObject drop = Instantiate(hpDrop, transform.position + new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), Random.Range(-2f, 2f)), Quaternion.identity, null);
            drop.GetComponent<Rigidbody>().AddExplosionForce(dropsExplosionForce, transform.position, 6f, 0.1f, ForceMode.Impulse);
        }
    }
}
