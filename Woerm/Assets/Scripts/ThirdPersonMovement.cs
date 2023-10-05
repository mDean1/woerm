using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    Vector3 m_Input;
    public float m_Speed = 5f;
    public Vector3 rotationSpeed = new Vector3(0,0,40);

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

   

    void FixedUpdate()
    {
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        Quaternion deltaRotation = Quaternion.Euler(m_Input.x * rotationSpeed * Time.deltaTime);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
        m_Rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * m_Speed);

        
    }
}
