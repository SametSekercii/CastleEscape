using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : Knights
{
    public enum PlayerState { isMoving,isAttacking}
    public PlayerState state;
    PlayerMovement _playerMovement;
    PlayerAnimationController PlayerAnimationController;
    PlayerInput _playerInput;
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        _playerInput = GetComponent<PlayerInput>();

        LevelTextInitializer();

        _playerMovement = new PlayerMovement(transform, rb, moveSpeed);
        PlayerAnimationController = new PlayerAnimationController(animator);
        
    }

    
    void FixedUpdate()
    {
        _playerMovement.Movement(_playerInput.moveVector);

        if(_playerInput.moveVector.magnitude > 0)
        {
            state= PlayerState.isMoving;

        }
        PlayerAnimationController.SetAnimations(_playerInput.moveVector);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Collectable collectable= other.GetComponent<Collectable>();

        if(collectable != null ) 
        {
            collectable.OnCollect();
            
        }
    }
    
    private void OnCollectBook(object levelUpAmount)
    {
       int  _levelUpAmount= (int)levelUpAmount;
        level += _levelUpAmount;
        levelText.text = "LV." + level.ToString();
    }
   

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnCollectBook, OnCollectBook);
    }
    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnCollectBook, OnCollectBook);
    }

    public override void TakeDamage()
    {
        isAlive = false;
        EventManager.Broadcast(GameEvent.OnFail);
    }
}
