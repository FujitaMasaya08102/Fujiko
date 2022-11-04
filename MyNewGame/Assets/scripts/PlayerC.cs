using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{
    CharacterController controller;
    Vector3 movedir = Vector3.zero;

    int Lane;

    public float speedX;
    public float speedZ;
    public float acceleratorZ;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left"))
        {
            if (controller.isGrounded && Lane > -1f)
            {
                Lane--;
            }
        }
        if (Input.GetKeyDown("right"))
        {
            if (controller.isGrounded && Lane < 1f)
            {
                Lane++;
            }
        }
        if (Input.GetKeyDown("space"))
        {
            if (controller.isGrounded)
            {
                movedir.y = 10f;
            }
        }

        movedir.z = Mathf.Clamp(movedir.z + (acceleratorZ * Time.deltaTime), 0, speedZ);

        float ratioX = (Lane * 1.0f - transform.position.x) / 1.0f;
        movedir.x = ratioX * speedX;



        movedir.y -= 20f * Time.deltaTime;

        Vector3 globaldir = transform.TransformDirection(movedir);
        controller.Move(globaldir * Time.deltaTime);

        if (controller.isGrounded)
        {
            movedir.y = 0;
        }
    }
}