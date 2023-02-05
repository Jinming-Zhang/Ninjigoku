using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobC : MonoBehaviour
{
    public int mobHealth = 1;
    public float chasingSpeed = 1f;
    public GameObject player;
    public GameObject MobDestroy;
    public GameObject MobD;
    public GameObject MobB;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
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
        Instantiate(MobB,transform.GetChild(0).transform.position,Quaternion.identity);
        Instantiate(MobD,transform.GetChild(1).transform.position,Quaternion.identity);
        Instantiate(MobD,transform.GetChild(2).transform.position,Quaternion.identity);
    }
}
