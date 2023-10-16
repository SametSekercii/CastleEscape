using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
  
    float movementSpeed;
    Transform playerTransform;
    Rigidbody playerRigidbody;
    

    
    public PlayerMovement(Transform _playerTransform,Rigidbody _playerRigidbody, float _movementSpeed)
    {
        this.playerTransform = _playerTransform;
        this.playerRigidbody = _playerRigidbody;
        this.movementSpeed = _movementSpeed;
    }
    
    public void Movement(Vector3 moveVector)
    {
        playerRigidbody.MovePosition(playerRigidbody.position+ moveVector*Time.deltaTime* movementSpeed);
        playerTransform.forward += moveVector;
    }
    
}
