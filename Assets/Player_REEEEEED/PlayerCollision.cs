using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public bool isDead { get; set; }

    public void Start()
    {
        isDead = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<MobA>() && !isDead)
        {
            Debug.Log("Player has been slain by MobA.");

            // change bool
            isDead = true;
            // GetComponent<CapsuleCollider>().enabled = false;
            // TODO: Enter Death Scene.
        }
    }
}
