using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    int health;
    bool dead=false;
    void SetHealth(int h)
    {
        health = h;
    }
    void TakeDamage(int val)
    {
        health -= val;
        if (health <= 0) dead = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
