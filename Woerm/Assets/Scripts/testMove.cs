using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMove : MonoBehaviour
{

    public Transform headBone; // The top bone of the worm.
    public float moveSpeed = 5.0f; // Adjust the speed of forward/backward movement.
    public float rotationSpeed = 90.0f; // Adjust the speed of rotation.

    private HingeJoint[] hingeJoints;
    private JointSpring[] originalSprings;

    void Start()
    {
        // Get all hinge joints in the chain.
        hingeJoints = GetComponentsInChildren<HingeJoint>();
        
        // Store the original spring settings for each hinge joint.
        originalSprings = new JointSpring[hingeJoints.Length];
        for (int i = 0; i < hingeJoints.Length; i++)
        {
            originalSprings[i] = hingeJoints[i].spring;
        }
    }

    void Update()
    {
        // Move the head bone forward/backward.
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = headBone.forward * verticalInput * moveSpeed * Time.deltaTime;

        // Rotate the head bone left/right.
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 rotation = Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime;

        // Apply the movement and rotation to the head bone.
        headBone.position += movement;
        headBone.Rotate(rotation);

        // Adjust the hinge joint springs to follow the head bone's rotation.
        for (int i = 0; i < hingeJoints.Length; i++)
        {
            JointSpring spring = hingeJoints[i].spring;
            spring.targetPosition = headBone.localEulerAngles.y;
            hingeJoints[i].spring = spring;
        }
    }
}


