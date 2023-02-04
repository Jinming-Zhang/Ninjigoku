using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobB : MonoBehaviour
{
    public int mobHealth = 1;
    public float chasingSpeed = 0.5f;
    public GameObject player;
    private Rigidbody playerRigidbody;
    public GameObject MobDestroy;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        //playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(player.transform.position);
        //Vector3 dir = player.transform.position - transform.position;
        transform.LookAt(player.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, chasingSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            print(collision.gameObject.name);
            Destroy(gameObject);
        }
    }

    void OnDestroy() 
    {
        Instantiate(MobDestroy, transform.position, Quaternion.identity);
        //Spawn powerups
        //Instantiate(DropPowerUp, transform.position, Quaternion.identity);
    }
}