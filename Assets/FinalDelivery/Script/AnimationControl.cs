using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using System;
public class AnimationControl : MonoBehaviour
{   
    //public static event Action OnRun;
    Animator animator;
    PlayerMovement playerMovement;
    PlayerCollision playerCollision;
    public float speed;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
    
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        playerCollision= GetComponent<PlayerCollision>();
    }
    private void Update()
    {
        if (playerMovement.isRunning && playerCollision.isDead == false)
        {
            animator.SetBool("isRunning", true);

        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (playerCollision.isDead == false)
        {
            float moveHorizontal = Input.GetAxisRaw("Horizontal");
            float moveVertical = Input.GetAxisRaw("Vertical");
         
            Vector3 movement = new Vector3(moveVertical, 0.0f, -moveHorizontal);
            if (movement != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movement);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
   
}
