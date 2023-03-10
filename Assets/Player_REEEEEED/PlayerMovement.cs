using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speedMove;
    [SerializeField]
    float degPerSec;

    [SerializeField] private Rigidbody rb;


   
    public bool isRunning;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }

    private void FixedUpdate()
    {

        
        if (!GetComponent<PlayerCollision>().isDead)
        {
            // Player Move
            Move();
            Debug.LogFormat("x: {0}, z: {1}", rb.position.x, rb.position.z);
            // Player Rotate
            //Rotate();
        }
        CheckControl();
        Vector3 v = rb.velocity;
        v.y = -1;
        rb.velocity = v;    }

    void Move()
    {
        // Debug.LogFormat("x: {0}, z: {1}", rb.position.x, rb.position.z);
        Vector3 pos = transform.position;
       
        if (Input.GetKey(KeyCode.W))
        {
            Debug.LogFormat("x: {0}, z: {1}", rb.position.x, rb.position.z);
            //transform.position += transform.forward * speedMove * Time.fixedDeltaTime;
            pos.x = pos.x + speedMove * Time.fixedDeltaTime;

            GetComponent<PlayAudio>().playFootStepsAudio();
        }
        if (Input.GetKey(KeyCode.S))
        {
            pos.x = pos.x - speedMove * Time.fixedDeltaTime;
            //transform.position -= transform.forward * speedMove * Time.fixedDeltaTime;

            GetComponent<PlayAudio>().playFootStepsAudio();
        }
        if (Input.GetKey(KeyCode.A))
        {
            pos.z = pos.z + speedMove * Time.fixedDeltaTime;
            //transform.position -= transform.right * speedMove * Time.fixedDeltaTime;

            GetComponent<PlayAudio>().playFootStepsAudio();
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos.z = pos.z - speedMove * Time.fixedDeltaTime;
            //transform.position += transform.right * speedMove * Time.fixedDeltaTime;

            GetComponent<PlayAudio>().playFootStepsAudio();
        }

        rb.MovePosition(pos);
        //transform.position = pos;
    }

    void Rotate()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector3 mousePosWorld = Vector3.one;
        mousePosWorld.x = mousePos.x;
        mousePosWorld.y = mousePos.y;
        mousePosWorld.z = Vector3.Distance(transform.position, Camera.main.transform.position);
        mousePosWorld = Camera.main.ScreenToWorldPoint(mousePosWorld);
        mousePosWorld.y = transform.position.y;

        Vector3 targetDir = mousePosWorld - transform.position;
        Vector3 current = transform.forward;
        Vector3 next = Vector3.RotateTowards(current, targetDir, degPerSec * Mathf.Deg2Rad * Time.fixedDeltaTime, 0);
        transform.forward = next;
    }

    void CheckControl() {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            isRunning = true;
        }
        else { 
            isRunning= false;
        }
    }
}
