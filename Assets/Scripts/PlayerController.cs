using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : Knights,IFieldOfView
{
    public enum PlayerState { isMoving,isAttacking,isWaiting,isDead}
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
        Debug.Log(state);
        CheckState();
        PlayerAnimationController.SetAnimations(state);

        if(isAlive)
        {
            _playerMovement.Movement(_playerInput.moveVector);
        }
        
       
    }

    private void CheckState()
    {

        if (isAlive)
        {
            if (_playerInput.moveVector.magnitude > 0)
            {
                state = PlayerState.isMoving;
            }
            else
            {
                state = PlayerState.isWaiting;
            } 
            if (GetVisibleTargets().Count > 0)
            {
                Transform target = GetVisibleTargets()[0];
                SetSeenTarget(target);

                IDamageable damageableTarget = target.GetComponent<IDamageable>();
                if (level > damageableTarget._level && damageableTarget._isAlive)
                {
                    state = PlayerState.isAttacking;
                }
                
            }

        }
        else
        {
            state = PlayerState.isDead;
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
    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        if (damageable != null)
        {
            if (level > damageable._level && damageable._isAlive)
            {
                target = collision.transform;
                state = PlayerState.isAttacking;
                Vector3 dirV = (target.position - transform.position).normalized;
                Quaternion lookDirection = Quaternion.LookRotation(dirV);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, lookDirection, 360);
            }

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
        target = null;
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
