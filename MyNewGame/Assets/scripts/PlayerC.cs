using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{
    float PlayerSpeed = 1.0f;


    CharacterController controller;
    Vector3 movedir = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {

            

            movedir.z = Input.GetAxis("Vertical") * PlayerSpeed;


            transform.Rotate(0, Input.GetAxis("Horizontal") * 0.5f, 0);

            if (Input.GetButton("Jump"))
            {
                movedir.y = 10f;
            }
        }

        movedir.y -= 20f * Time.deltaTime;

        Vector3 globaldir = transform.TransformDirection(movedir);
        controller.Move(globaldir * Time.deltaTime);

        if (controller.isGrounded)
        {
            movedir.y = 0;
        }
    }
}