using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobA : MonoBehaviour
{
    public int mobHealth = 1;
    public float chasingSpeed = 0.5f;
    public GameObject player;
    //private Rigidbody _Rigidbody;
    public GameObject MobDestroy;
    //public double Timer;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        //_Rigidbody = GetComponent<Rigidbody>();
        //_Rigidbody.isKinematic = True;
        //Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Timer<=1){
        //    Timer+=Time.deltaTime;
        //    if (Timer>=1){
        //        _Rigidbody.isKinematic = False;
        //    }
        //}

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
