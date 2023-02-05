using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniRoot : MonoBehaviour
{
    public float speed = 2.5f;
    public float spawnTime = 4f;
    public GameObject mobA;
    public GameObject mobB;
    public float lootProbability  = 10f;
    public EnemyType _TYPE = EnemyType.MiniRoot;
    public int miniRootHP = 10;

    [SerializeField]
    private Vector3 destination = Vector3.zero;
    private float timerForSpawn;
    private int spawnMultiplier = 1;
    private Vector3[] spawnLocations = {
            Vector3.left + Vector3.forward,
            Vector3.forward,
            Vector3.right + Vector3.forward,
            Vector3.left,
            Vector3.right, Vector3.up*2,
            Vector3.left + Vector3.back,
            Vector3.back,
            Vector3.right + Vector3.back,
            Vector3.left + Vector3.up,
            Vector3.right + Vector3.up
        };
    private int spawnLocationsIndex = 0;
    private int hit;
    // Start is called before the first frame update
    void Start()
    {
        timerForSpawn = spawnTime;
        hit = 0;

        // spawn 5 mobs at the beginning
        for (int i = 0; i < 4; i++) {
            if (lootCheck()) {
                spawnB();
            } else {
                spawnA();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement(destination);
        handleSpawn();
    }

    private void Movement(Vector3 target) {
        transform.LookAt(destination);
        Vector3 me = transform.position;
        me.y = 0;
        transform.position = Vector3.MoveTowards(me, destination, speed * Time.deltaTime);
    }

    private void handleSpawn() {
        timerForSpawn -= Time.deltaTime;

        if (timerForSpawn < 0) {
            for (int i = 0; i < 8; i++) {
                if (lootCheck()) {
                    spawnB();
                } else {
                    spawnA();
                }
            }
            timerForSpawn = spawnTime;
        }
    }

    private Vector3 getSpawnLocation() {
        Vector3 loc = spawnLocations[spawnLocationsIndex++] * spawnMultiplier
                        + this.transform.position
                        + Vector3.up * 2;
        if (spawnLocationsIndex == spawnLocations.Length) {
            spawnLocationsIndex = 0;
        }
        return loc;
    }

    private void spawnA() {
        Instantiate(mobA, getSpawnLocation(), Quaternion.identity);
    }

    private void spawnB() {
        Instantiate(mobB, getSpawnLocation(), Quaternion.identity);
    }

    private bool lootCheck() {
        return Random.Range(0, 100) < this.lootProbability;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("hit!");
            hit++;
            if (hit >= miniRootHP) Destroy(gameObject);
        }
    }

}
