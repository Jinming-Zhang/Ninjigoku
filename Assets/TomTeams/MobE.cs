using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobE : MonoBehaviour
{
 //   public Boolean gotHit = False;
    public int mobHealth = 3;
    public float chasingSpeed = 0.5f;
    public GameObject player;
    public GameObject MobDestroy;
    public GameObject DropPowerUp;
    public double Timer = 0;
    private Rigidbody _Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        _Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (gotHit==True){
        //    Timer+=Time.deltaTime;
        //    chasingSpeed*=Math.pow(Timer,2)-4*Timer+4;
        //}
        transform.LookAt(player.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, chasingSpeed * Time.deltaTime);
        
        if (mobHealth<=0){
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Player")
        {
            mobHealth-=1;
            _Rigidbody.AddForce(-10 * transform.forward, ForceMode.Impulse);
            chasingSpeed *= 2;
        }
    }

    void OnDestroy() 
    {
        Instantiate(MobDestroy, transform.position, Quaternion.identity);
        //Spawn powerups
        //Instantiate(DropPowerUp, transform.position, Quaternion.identity);
    }
}