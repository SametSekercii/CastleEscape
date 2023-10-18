using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerController : Knights
{
    private float moveSpeed=5;
    PlayerMovement _playerMovement;
    PlayerAnimationController PlayerAnimationController;
    PlayerInput _playerInput;
    void Start()
    {
        LevelTextInitializer();
        _playerInput = GetComponent<PlayerInput>();
        _playerMovement = new PlayerMovement(transform, GetComponent<Rigidbody>(), moveSpeed);
        PlayerAnimationController = new PlayerAnimationController(GetComponent<Animator>());
        
    }

    
    void FixedUpdate()
    {
        _playerMovement.Movement(_playerInput.moveVector);
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
    protected override void Attack()
    {

    }

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnCollectBook, OnCollectBook);
    }
    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnCollectBook, OnCollectBook);
    }
}
