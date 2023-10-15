using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    Joystick joystick;
    float movementSpeed;
    Transform playerTransform;
    Rigidbody playerRigidbody;
    Animator playerAnimator;
    

    
    public PlayerMovement(Transform _playerTransform,Rigidbody _playerRigidbody, Animator _playerAnimator,Joystick joystick, float _movementSpeed)
    {
        this.playerTransform = _playerTransform;
        this.joystick = joystick;
        this.playerRigidbody = _playerRigidbody;
        this.movementSpeed = _movementSpeed;
        this.playerAnimator = _playerAnimator;  

    }
    
    public void Movement()
    {


        Vector3 moveDirection = new Vector3(joystick.Horizontal*Time.deltaTime* movementSpeed, 0, joystick.Vertical * Time.deltaTime * movementSpeed);
        Vector3 lookDirection = new Vector3(joystick.Horizontal , 0, joystick.Vertical);
        playerRigidbody.MovePosition(playerRigidbody.position+ moveDirection);
        playerTransform.forward += lookDirection;

        if(joystick.Horizontal==0 && joystick.Vertical==0)
        {
            playerAnimator.SetBool("isRun", false);
        }
        else if(joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            playerAnimator.SetBool("isRun", true);
        }


    }
    
}
