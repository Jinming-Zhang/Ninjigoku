using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobFrozen : MonoBehaviour
{	
    public float safeDistance= 2f;
	public GameObject player;
    public float speed = 2f;
    public int mobHealth=1;
    private Rigidbody playerRigidbody;
    public float lockDuration = 2f;
    private bool isLockingMovement = false;
    private float startTime;
    public float safeTime;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
          if (!isLockingMovement)
        {	
            if (Vector2.Distance(transform.position, player.transform.position) < safeDistance)
            {
                transform.LookAt(player.transform.position);
                startTime = Time.time;

                if(Time.time - startTime >= safeTime)
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                }
            }
            else{
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }

            if (Vector2.Distance(transform.position, player.transform.position) < 0.01f)
            {
                StartCoroutine(LockPlayerMovement());
                Destroy(gameObject);
            }
        }

        // transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

      void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Destroy(gameObject);
        }
    }
    
    //    void OnDestroy()
    // {
    //     Instantiate(MobDestroy, transform.position, Quaternion.identity);
    // }

        IEnumerator LockPlayerMovement()
    {
        isLockingMovement = true;
        // Lock player's movement here (e.g., by disabling a player controller script)

        yield return new WaitForSeconds(lockDuration);

        isLockingMovement = false;
        // Unlock player's movement here (e.g., by enabling a player controller script)
    }
}
