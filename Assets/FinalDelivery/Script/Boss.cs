using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Boss : MonoBehaviour
{
    [SerializeField]
    float maxHealth;

   
    public AudioClip deathSound; 
    public float health;
    bool dead;
   
    // Start is called before the first frame update
    void Start()
    {
       
        health = maxHealth;
        dead = false;
    }

   
    public void TakeDamage(float dmg)
    {
        health = Mathf.Max(0, health - dmg);
        
        if (health == 0)
        {
            if (!dead)
            {   
                AudioSystem.Instance.PlaySFX(deathSound);
                dead = true;
                GameStatus.Instance.PlayerWin();
                Die();
            }
        }
    }

    private void Die()
    {

    }
}
