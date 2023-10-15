using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Joystick floatingJoystick;
    PlayerMovement _playerMovement;
    Animator animator;
    Rigidbody rb;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        _playerMovement = new PlayerMovement(transform, rb, animator,floatingJoystick,5);
        
    }

    
    void Update()
    {
        _playerMovement.Movement();
        
    }
}
