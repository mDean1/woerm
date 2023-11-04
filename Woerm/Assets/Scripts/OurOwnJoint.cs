using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OurOwnJoint : MonoBehaviour {
    // Here is our configuration params
    public Rigidbody connectedBody;
    public Vector3 anchor;
    public bool autoConfigureConnectedAnchor;
    public Vector3 connectedAnchor;
    public Vector3 secondaryAxis;
    public Vector3 axis;
    public ConfigurableJointMotion xMotion;
    public ConfigurableJointMotion yMotion;
    public ConfigurableJointMotion zMotion;

   

    void Awake(){
        GetComponent<ConfigurableJoint>().connectedBody = transform.parent.GetComponent<Rigidbody>();
    }

}
