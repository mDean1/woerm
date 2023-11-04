using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parentCopy : MonoBehaviour
{
    private Transform connectedBone;  // The bone to follow.

    public float maxAngle = 45.0f; // Maximum rotation angle.

    private Quaternion initialRotation;

    void Start()
    {
        if (connectedBone != null)
        {
            initialRotation = transform.rotation;
        }
    }

    void Update()
    {
        if (connectedBone != null)
        {
            // Calculate the relative rotation between this bone and the connected bone.
            Quaternion relativeRotation = Quaternion.Inverse(connectedBone.rotation) * initialRotation;

            // Extract the Euler angles from the relative rotation.
            Vector3 relativeEulerAngles = relativeRotation.eulerAngles;

            // Apply a rotation constraint to limit the angle for each component.
            relativeEulerAngles.x = Mathf.Clamp(relativeEulerAngles.x, -maxAngle, maxAngle);
            relativeEulerAngles.y = Mathf.Clamp(relativeEulerAngles.y, -maxAngle, maxAngle);
            relativeEulerAngles.z = Mathf.Clamp(relativeEulerAngles.z, -maxAngle, maxAngle);

            // Update the rotation of this bone.
            transform.rotation = connectedBone.rotation * Quaternion.Euler(relativeEulerAngles);
        }
    }
}
