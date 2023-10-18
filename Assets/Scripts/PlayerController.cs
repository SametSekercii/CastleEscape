using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed=5;
    PlayerMovement _playerMovement;
    PlayerAnimations _playerAnimations;
    PlayerInput _playerInput;
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerMovement = new PlayerMovement(transform, GetComponent<Rigidbody>(), moveSpeed);
        _playerAnimations=new PlayerAnimations(GetComponent<Animator>());
        
    }

    
    void FixedUpdate()
    {
        _playerMovement.Movement(_playerInput.moveVector);
        _playerAnimations.SetAnimations(_playerInput.moveVector);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Collectable collectable= other.GetComponent<Collectable>();

        if(collectable != null ) 
        {
            collectable.OnCollect();
            
        }
    }
}
