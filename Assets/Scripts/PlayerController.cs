using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerMovement _playerMovement;
    PlayerAnimations _playerAnimations;
    PlayerInput _playerInput;
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerMovement = new PlayerMovement(transform, GetComponent<Rigidbody>(),5);
        _playerAnimations=new PlayerAnimations(GetComponent<Animator>());
        
    }

    
    void FixedUpdate()
    {
        _playerMovement.Movement(_playerInput.moveVector);
        _playerAnimations.SetAnimations(_playerInput.moveVector);
        
    }
}
