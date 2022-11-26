using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerC : MonoBehaviour
{

    CharacterController controller;
    Vector3 movedir = Vector3.zero;

    int Lane;

    public float speedX;
    public float speedZ;
    public float acceleratorZ;
    Animator animator;
    const int MaxLife = 3;
    const float Duration = 0.5f;
    int life = MaxLife;
    float RecoveryTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

    }
    public int Life()
    {

        return life;

    }
    bool IsStun()
    {

        return RecoveryTime > 0.0f || life <= 0;

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left"))
        {
            if (IsStun())
            {
                return;
            }

            if (controller.isGrounded && Lane > -2f)
            {
                Lane--;
            }
        }
        if (Input.GetKeyDown("right"))
        {
            if (IsStun())
            {
                return;
            }
            if (controller.isGrounded && Lane < 2f)
            {
                Lane++;
            }
        }
        if (Input.GetKeyDown("space"))
        {
            if (IsStun())
            {
                return;
            }

            if (controller.isGrounded)
            {
                movedir.y = 10f;
                animator.SetTrigger("Jump");
            }
        }

        if (IsStun())
        {
            movedir.x = 0.0f;
            movedir.z = 0.0f;
            RecoveryTime -= Time.deltaTime;
            if (life == 0)
            {
                animator.SetTrigger("Stand");
                
            }
        
        }
        else
        {
            movedir.z = Mathf.Clamp(movedir.z + (acceleratorZ * Time.deltaTime), 0, speedZ);

            float ratioX = (Lane * 1.0f - transform.position.x) / 1.0f;
            movedir.x = ratioX * speedX;
        }


        movedir.y -= 20f * Time.deltaTime;

        Vector3 globaldir = transform.TransformDirection(movedir);
        controller.Move(globaldir * Time.deltaTime);

        if (controller.isGrounded)
        {
            movedir.y = 0;
        }

        animator.SetBool("Run", movedir.z > 0.0f);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (IsStun())
        {
            return;
        }
        if (hit.gameObject.tag == "Enemy")
        {
            life--;
            RecoveryTime = Duration;
            animator.SetTrigger("Damage");
            Destroy(hit.gameObject);
        }
        
    }



}