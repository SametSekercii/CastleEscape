using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardEnemy : Enemy
{
    public enum GuardEnemyState{isObservering,isAttacking ,isChargingTarget,isMovingGuardPoint}

    GuardEnemyState state=GuardEnemyState.isObservering;
    GuardEnemyAnimationController animationController;
    Vector3 guardPointPos;
    Quaternion guardPointRot;



    private void Start()
    {
        agent=GetComponent<NavMeshAgent>();
        fieldOfView = GetComponent<Perspective>();
        animator = GetComponent<Animator>();

        SetGuardPointValues();
        LevelTextInitializer();
        
        animationController = new GuardEnemyAnimationController(animator);
    }
    private void Update()
    {
        animationController.SetAnimations(state);

        Mission();

    }

    void Mission()
    {
        switch (state) 
        {
            case GuardEnemyState.isObservering:
                Observe();
                //Debug.Log("Observing");
                break;
            case GuardEnemyState.isChargingTarget:
                Charge(target);
                //Debug.Log("Charging");
                break;
            case GuardEnemyState.isAttacking:
                
                //Debug.Log("Atttacking");
                break;
            case GuardEnemyState.isMovingGuardPoint:
                //Debug.Log("MovingGuardPoint");
                MoveGuardPoint();
                break;
        
        
        }
    }
    private void MoveGuardPoint()
    {
        agent.SetDestination(guardPointPos);
        if(Vector3.Distance(guardPointPos, transform.position)<0.2f)
        {

            transform.localRotation = guardPointRot;
            state = GuardEnemyState.isObservering;
            
        }
    }
    protected override void Attack()
    {
        IDamageable damageable=target.GetComponent<IDamageable>();
        if(damageable._isAlive)
        {
            agent.SetDestination(transform.position);
            damageable.TakeDamage();
        }
        else StartCoroutine(DelayedStateChange(GuardEnemyState.isMovingGuardPoint));


    }
   IEnumerator DelayedStateChange(GuardEnemyState _state)
    {
        yield return new WaitForSeconds(1f);
        state = _state;
    }
    private void Charge(Transform target)
    {
        Vector3 targetPos = target.position;
        agent.SetDestination(targetPos);

        if (Vector3.Distance(transform.position, targetPos) < attackRange)
        {
            state = GuardEnemyState.isAttacking;
        }

        if (GetVisibleTargets().Count <= 0) state = GuardEnemyState.isMovingGuardPoint;

    }
    private void Observe()
    {
        if (GetVisibleTargets().Count > 0)
        {
            Transform target = GetVisibleTargets()[0];

            IDamageable damageableTarget = target.GetComponent<IDamageable>();
            if (level > damageableTarget._level && damageableTarget._isAlive)
            {
                SetSeenTarget(target);
                state = GuardEnemyState.isChargingTarget;
            }
        }
        else state= GuardEnemyState.isObservering;


    }
   

    private void SetGuardPointValues()
    {
        guardPointPos = transform.position;
        guardPointRot = transform.localRotation;
    }
    

}
