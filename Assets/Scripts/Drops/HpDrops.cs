using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpDrops : DropsBase
{
    //private Transform player;
    [SerializeField] private float heal = 1f;
    //private float timerBeforeFollow = 0.8f;
    //private bool follow = false;
    //[SerializeField] private float speed = 5f;

    //[SerializeField] private Rigidbody rb;

    // Start is called before the first frame update
    /*void Start()
    {
        player = GameManager.instance.player.transform;
    }*/

    // Update is called once per frame
    /*void Update()
    {
        if (timerBeforeFollow > 0f)
        {
            timerBeforeFollow -= Time.deltaTime;
        }
        else
        {
            rb.MovePosition(Vector3.MoveTowards(transform.position, player.position, speed));
        }
    }*/

    public float getHealAmount()
    {
        return heal;
    }

    public override void ApplyEffect()
    {
        GameManager.instance.player.HealPlayer(heal);
    }
}
