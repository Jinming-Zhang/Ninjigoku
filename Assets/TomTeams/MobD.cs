using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobD : MonoBehaviour
{
    public int mobHealth = 1;
    public float chasingSpeed = 2f;
    public GameObject player;
    //private Rigidbody playerRigidbody;
    public GameObject MobDestroy;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        print("1");
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
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        Instantiate(MobDestroy, transform.position, Quaternion.identity);
    }
}
