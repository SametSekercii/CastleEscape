using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHinge : MonoBehaviour
{
    HingeJoint hinge;
    JointMotor motor;
    Rigidbody rb;
    float V;
    float angle;
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        hinge=GetComponent<HingeJoint>();
        motor=hinge.motor;
    }
    void FixedUpdate()
    {
        CloseAutomaticly();   
    }
    void CloseAutomaticly()
    {
        angle=hinge.angle;
        motor.targetVelocity = -angle;
        hinge.motor=motor;
    }
   
}
