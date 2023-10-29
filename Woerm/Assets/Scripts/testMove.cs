using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMove : MonoBehaviour
{

     // The Rigidbody attached to the GameObject.
    private Rigidbody body;

    /// Speed scale for the velocity of the Rigidbody.

    public float speed;

    /// Rotation Speed scale for turning.

    public float rotationSpeed;

    /// The upwards jump force of the player.

    // The vertical input from input devices.
    private float vertical;
    // The horizontal input from input devices.
    private float horizontal;

    // Initialization function
    void Start()
    {
        // Obtain the reference to our Rigidbody.
        body = GetComponent<Rigidbody>();
 
    }
    // Fixed Update is called a fix number of frames per second.
    void FixedUpdate()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        
        Vector3 velocity = (transform.forward * vertical) * speed * Time.fixedDeltaTime;
        velocity.y = body.velocity.y;
        body.velocity = velocity;
        transform.Rotate((transform.right * horizontal) * rotationSpeed * Time.fixedDeltaTime);
    }
   
}


