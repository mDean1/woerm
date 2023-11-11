using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMove : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float rotationSpeed = 180f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Set rigidbody constraints to freeze rotation in the X and Z axes
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement and rotation
        Vector3 movement = new Vector3(0f, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(0f, horizontalInput * rotationSpeed * Time.deltaTime, 0f);

        // Apply movement and rotation
        rb.MovePosition(rb.position + transform.TransformDirection(movement));
        rb.MoveRotation(rb.rotation * rotation);
    }
}


