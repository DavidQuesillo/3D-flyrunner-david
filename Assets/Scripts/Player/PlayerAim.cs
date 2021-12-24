using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public Transform cam;
    Vector2 rotation = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AimShooting();
    }

    void AimShooting()
    {
        if (GameManager.instance.currentState == EGameStates.Gameplay)
        {
            cam = Camera.main.transform;

            rotation.y += Input.GetAxis("Mouse X");
            rotation.x += -Input.GetAxis("Mouse Y");

            //cam.SetPositionAndRotation(cam.position, new Quaternion(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), cam.rotation.y, cam.rotation.z));

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
    }
}
