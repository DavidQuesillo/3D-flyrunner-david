using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunning : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float jumpForce = 1f;
    [SerializeField] private bool isGrounded;

    [SerializeField]
    private float goalForce = 200f;
    Vector2 rotation = Vector2.zero;
    public Transform cam;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private PlayerGlobal pg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveHorizontal();
        //AimShooting();
        Jump();
    }

    private void MoveHorizontal()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        cam = Camera.main.transform;
        Vector3 direction = cam.forward * v + cam.right * h; //new Vector3(h, 0, v);
        //direction.y = 0f;
        Vector3 finalvelocity = direction * speed;
        finalvelocity.y = rb.velocity.y;
        rb.velocity = finalvelocity;

        //rb.AddForce(direction * speed, ForceMode.Acceleration);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
                isGrounded = false;
            }
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
        if (collision.gameObject.CompareTag("Finish"))
        {
            rb.AddForce(Vector3.up * goalForce, ForceMode.Impulse);
        }

        if (collision.GetContact(0).normal.y >= 0f)
        {
            isGrounded = true;
        }
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
