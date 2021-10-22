using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float hSpeed = 1f;
    [SerializeField]
    private float vSpeed = 1f;

    Vector2 rotation = Vector2.zero;
    public Transform cam;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private PlayerGlobal pg;

    // Start is called before the first frame update
    void Start()
    {
        rb.useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        MoveHorizontal();
        MoveVertical();
        //AimShooting();

        if (rb.velocity.y <= 0f)
        {
            rb.useGravity = false;
        }
    }

    private void MoveHorizontal()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        cam = Camera.main.transform;
        Vector3 direction =  cam.forward * v + cam.right * h; //new Vector3(h, 0, v);
        Vector3 finalvelocity = direction * hSpeed;
        finalvelocity.y = rb.velocity.y;
        rb.velocity = finalvelocity;
    }

    private void MoveVertical()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector3 (rb.velocity.x, vSpeed, rb.velocity.z);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            rb.velocity = new Vector3(rb.velocity.x, -vSpeed, rb.velocity.z);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        }
    }

    /*void AimShooting()
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
    }*/

    private void OnCollisionEnter(Collision collision)
    {

    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("EnemyBullet"))
        {
            pg.DamagePlayer(other.transform.GetComponent<EnemyBulletBase>().GetDamage());
            Destroy(other.gameObject);

        }
    }*/
}
