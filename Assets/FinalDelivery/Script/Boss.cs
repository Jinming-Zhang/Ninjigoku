using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]
    float maxHealth;

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
