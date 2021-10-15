using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGlobal : MonoBehaviour
{
    [SerializeField]
    private Attributes hp = new Attributes(10);

    [SerializeField]
    private bool isFlying;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private PlayerMovement pm;
    [SerializeField]
    private PlayerRunning pr;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void DamagePlayer(float ouch)
    {
        hp.SubstractToAttrtibute(ouch);
    }
}
