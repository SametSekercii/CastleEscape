using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    Joystick joystick;
    float movementSpeed;
    Transform playerTransform;

    public PlayerMovement(Transform _playerTransform, Joystick joystick, float _movementSpeed)
    {
        this.joystick = joystick;
        this.playerTransform = _playerTransform;
        this.movementSpeed = _movementSpeed;

    }
    public void Movement()
    {
        Vector3 direction= new Vector3(joystick.Horizontal,0,joystick.Vertical);
        playerTransform.position+= direction*Time.deltaTime*movementSpeed;
        playerTransform.forward += direction;

    }
    
}
