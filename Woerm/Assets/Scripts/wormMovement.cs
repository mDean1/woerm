using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wormMovement : MonoBehaviour
{
    
    Rigidbody m_Rigidbody;
    Vector3 m_Input;
    public float m_Speed = 5f;
    public Vector3 rotationSpeed = new Vector3(0, 40, 0);

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

       
    void FixedUpdate()
    {
    
        m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Quaternion deltaRotation = Quaternion.Euler(0, m_Input.x * rotationSpeed.y * Time.deltaTime, 0);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
        // Move the character based on its local forward direction
        Vector3 localForward = transform.TransformDirection(Vector3.forward);
        m_Rigidbody.MovePosition(transform.position + localForward * m_Input.z * Time.deltaTime * m_Speed);
    }
    

 /*   Rigidbody m_Rigidbody;
    Vector3 m_Input;
    public float m_Speed = 5f;
    public Vector3 rotationSpeed = new Vector3(0, 40, 0);

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

       
    void FixedUpdate()
    {
        m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //Quaternion deltaRotation = Quaternion.Euler(0, m_Input.x * rotationSpeed.y * Time.deltaTime, 0);
        //m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);

        m_Rigidbody.angularVelocity = new Vector3(0, m_Input.x * rotationSpeed.y, 0);
        // Move the character based on its local forward direction
        Vector3 localForward = transform.TransformDirection(Vector3.forward);
        m_Rigidbody.velocity = localForward * m_Input.z * m_Speed;
        //m_Rigidbody.MovePosition(transform.position + localForward * m_Input.z * Time.deltaTime * m_Speed);
    }
*/
//float rotationInput = Input.GetAxis("Horizontal");
//transform.Rotate(Vector3.up * rotationInput * rotationSpeed * Time.deltaTime);
}
