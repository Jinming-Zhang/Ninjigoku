using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speedMove;
    [SerializeField]
    float degPerSec;

    [SerializeField] private Rigidbody rb;

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        // Player Move
        Move();

        // Player Rotate
        Rotate();
        //Rotate2();
    }

    void Move()
    {
        // Debug.LogFormat("x: {0}, z: {1}", rb.position.x, rb.position.z);
        Vector3 pos = transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            pos.x = pos.x + speedMove * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            pos.x = pos.x - speedMove * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            pos.z = pos.z + speedMove * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos.z = pos.z - speedMove * Time.fixedDeltaTime;
        }

        rb.MovePosition(pos);
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
}
