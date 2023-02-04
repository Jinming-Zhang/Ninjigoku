using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float angleOffset;
    [SerializeField]
    float speedMove;
    [SerializeField]
    float speedRotate;
    // private bool facingRight = false;
    // private bool facingLeft = false;
    // private bool facingDown = false;
    // private bool facingUp = true;

    [SerializeField] private Rigidbody rb;

    private void Start()
    {
        //horizontal = 5.0f;
        //vertical = 5.0f;
    }

    private void FixedUpdate()
    {
        // Player Move
        Move();

        // Player Rotate
        Rotate();
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
        // Object Screen Position
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        // Mouse Screen Position
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        // Find Angle
        float angle = Mathf.Atan2(positionOnScreen.x - mouseOnScreen.x, 
            positionOnScreen.y - mouseOnScreen.y) * Mathf.Rad2Deg;

        Quaternion idealRotation = Quaternion.Euler(new Vector3(0f, angle + angleOffset, 0f));
        Quaternion currentRotation = transform.rotation;
        float rotationDiff = idealRotation.eulerAngles.y - currentRotation.eulerAngles.y;
        float yRotation = currentRotation.eulerAngles.y;

        // Stop Rotation When Close Enough
        if (Mathf.Abs(rotationDiff) > 3f)
        {
            // Rotate Left
            if (rotationDiff > 180f || (rotationDiff < 0 && rotationDiff > -180f))
            {
                yRotation -= speedRotate * Time.fixedDeltaTime;
            }
            // Rotate Right
            else if (rotationDiff <= 180f || rotationDiff <= -180f)
            {
                yRotation += speedRotate * Time.fixedDeltaTime;
            }
        }

        transform.rotation = Quaternion.Euler(new Vector3(0f, yRotation, 0f));
    }
}
