using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    Animator animator;
    CharacterController characterController;
    bool canMove = true;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove == false)
        {
            return;
        }

        if(Input.GetKey(KeyCode.W))
        {
            float speed = 1.0f;

            if(Input.GetKey(KeyCode.LeftShift))
            {
                speed = 3.0f;
                animator.SetBool("Running", true);
            }
            else
            {
                animator.SetBool("Running", false);
            }

            characterController.SimpleMove(transform.TransformDirection(Vector3.forward * speed));

            animator.SetBool("Walking", true);
            animator.SetBool("BackWalking", false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            float speed = 1.0f;
            
            characterController.SimpleMove(transform.TransformDirection(Vector3.back * speed));

            animator.SetBool("Walking", false);
            animator.SetBool("BackWalking", true);
        }
        else
        {
            animator.SetBool("BackWalking", false);
            animator.SetBool("Walking", false);
            animator.SetBool("Running", false);
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0.0f, -3.0f, 0.0f);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0.0f, 3.0f, 0.0f);
        }
    }

    public void Die()
    {
        canMove = false;

        animator.SetTrigger("Die");
    }

    public void Win()
    {
        canMove = false;

        animator.SetTrigger("Victory");
    }

}
