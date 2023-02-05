using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   //1. Movement- moving forward from spawn position, with Player's rotation
    //2. Collision - collide with player, destroy player and the bullet
    //3. 
    public GameObject bulletMesh;
    public float speed = 5f;

    [SerializeField]
    Vector3 movement;
    [SerializeField]
    Vector3 forward;

    [SerializeField]
    float bulletLifeSpan;
    float bulletAge;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void updateBulletAge()
    {
        if (bulletAge >= bulletLifeSpan)
        {
            Destroy(this.gameObject);
        }
        bulletAge += Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        updateBulletAge();
    }

    private void Movement() {
        movement = transform.forward;

        this.transform.Translate(movement * speed * Time.deltaTime, Space.World);
        //transform.position = transform.position + movement * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {//call collision game object damage enemy
        if (collision.gameObject.tag == "Player") {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
