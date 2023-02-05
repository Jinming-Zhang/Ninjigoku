using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerCollision : MonoBehaviour
{
    public bool isDead;
    public AudioClip playerDeathSound;
    Animator anim;
    public void Start()
    {
        isDead = true;
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<MobA>() && !isDead)
        {
            Debug.Log("Player has been slain by MobA.");
            //Play sound and animation
            anim.SetTrigger("triggerDeath");
            

            AudioSystem.Instance.PlaySFX(playerDeathSound);
            // change bool
            isDead = true;
            LoseCanvas.Instance.Show();
            // GetComponent<CapsuleCollider>().enabled = false;
            // TODO: Enter Death Scene.
        }
    }
}
