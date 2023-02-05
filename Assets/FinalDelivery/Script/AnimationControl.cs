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
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponentInParent<PlayerMovement>();
        playerCollision= GetComponentInParent<PlayerCollision>();
    }
    private void Update()
    {
        if (playerMovement.isRunning && playerCollision.isDead==false)
        {
            animator.SetBool("isRunning", true);
           
        }
        else {
            animator.SetBool("isRunning", false);
        }

        
    }
   
}
