using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : Knights,IFieldOfView
{
    public enum PlayerState { isMoving,isAttacking,isWaiting}
    public PlayerState state;
    PlayerMovement _playerMovement;
    PlayerAnimationController PlayerAnimationController;
    PlayerInput _playerInput;
    public Perspective fieldOfView { get; set; }

    void Start()
    {
        rb=GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        _playerInput = GetComponent<PlayerInput>();
        fieldOfView=GetComponent<Perspective>();

        LevelTextInitializer();

        _playerMovement = new PlayerMovement(transform, rb, moveSpeed);
        PlayerAnimationController = new PlayerAnimationController(animator);
        
    }
    
    void FixedUpdate()
    {
        CheckState();
        _playerMovement.Movement(_playerInput.moveVector);
        PlayerAnimationController.SetAnimations(state);
    }

    private void CheckState()
    {
        if (_playerInput.moveVector.magnitude > 0)
        {
            state = PlayerState.isMoving;
        }
        else state = PlayerState.isWaiting;
        if(GetVisibleTargets().Count > 0)
        {
            Transform target = GetVisibleTargets()[0];
            SetSeenTarget(target);

            IDamageable damageableTarget = target.GetComponent<IDamageable>();
            if (level > damageableTarget._level && damageableTarget._isAlive)
            {
                state= PlayerState.isAttacking;
            }
        }
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
    public override void TakeDamage()
    {
        isAlive = false;
        EventManager.Broadcast(GameEvent.OnFail);
    }

    protected override void Attack()
    {
        target.GetComponent<IDamageable>().TakeDamage();
        PlayerAnimationController.StopAttack();
    }
    public List<Transform> GetVisibleTargets() => fieldOfView.visibleTargets;
    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnCollectBook, OnCollectBook);
    }
    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnCollectBook, OnCollectBook);
    }




}
