using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Joystick floatingJoystick;
    PlayerMovement _playerMovement;
    void Start()
    {
        _playerMovement = new PlayerMovement(transform,floatingJoystick,5);
        
    }

    
    void Update()
    {
        _playerMovement.Movement();
        
    }
}
