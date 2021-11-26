using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBase : MonoBehaviour
{
    [SerializeField]
    private float damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetDamage()
    {
        return damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<PlayerGlobal>()?.DamagePlayer(damage);
        Destroy(gameObject);
    }
}
