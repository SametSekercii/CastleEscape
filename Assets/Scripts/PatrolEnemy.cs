using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;
using Newtonsoft.Json.Bson;


public class PatrolEnemy : Enemy
{
    public enum PatrolEnemyState { isPatrolling,isChargingTarget,isAttacking, isBackingToPatrol,isDeath }
    public  PatrolEnemyState state=PatrolEnemyState.isPatrolling;
    PatrolEnemyAnimationController animationController;
    public bool isReversePatrol;
    PatrolPath path;
    Vector3 targetPos;
 
    int index = 0;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb =GetComponent<Rigidbody>();
        animator=GetComponent<Animator>();
        path = GetComponent<PatrolPath>();
        fieldOfView = GetComponent<Perspective>();
        animationController = new PatrolEnemyAnimationController(animator);
        LevelTextInitializer();

        targetPos = path.GetPathPoint(0);

    }

    private void FixedUpdate()
    {
        
        if(isAlive)
        {
            Mission();
        }
       else
        {
            state = PatrolEnemyState.isDeath;
        }
       
        
        animationController.SetAnimations(state);

    }

    private void Mission()
    {
        Observe();
        switch (state) 
        {
            case PatrolEnemyState.isBackingToPatrol:
                BackToPatrol();
                //Debug.Log("isBackingToPatrol");
                break;
            case PatrolEnemyState.isChargingTarget:
                Charge(target);
                //Debug.Log("Charging");
                break;
            case PatrolEnemyState.isAttacking:

                //Debug.Log("Atttacking");
                break;
            case PatrolEnemyState.isPatrolling:
                Patrol();
                //Debug.Log("Patrolling");
                break;
        }

    }
    private void BackToPatrol()
    {

        agent.SetDestination(targetPos);
        
        if(Vector3.Distance(transform.position,targetPos)<0.6f) state = PatrolEnemyState.isPatrolling;
    }
    private void Patrol()
    {
        agent.speed = 2;
        if (Vector3.Distance(transform.position, targetPos) < 0.5f)
        {
            SetNewTargetPos();
            agent.SetDestination(targetPos);
        }
    }
    private void SetNewTargetPos()
    {
        if(index==path.lenght-1)
        {
           if(isReversePatrol) path.ReversePath();

            index = 0;
            targetPos = path.GetPathPoint(index);
            
            return;
        }
        index++;
        targetPos = path.GetPathPoint(index);
    }
    private void Charge(Transform target)
    {
        agent.speed = 5;
        Vector3 targetPos = target.position;
        agent.SetDestination(targetPos);

        if (Vector3.Distance(transform.position, targetPos) < attackRange)
        {
            state = PatrolEnemyState.isAttacking;
        }

        if (GetVisibleTargets().Count <= 0) state = PatrolEnemyState.isBackingToPatrol;
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
                state = PatrolEnemyState.isChargingTarget;
            }
        }
    }
    public override void Hit()
    {
        IDamageable damageable = target.GetComponent<IDamageable>();
        if (damageable._isAlive)
        {
            agent.SetDestination(transform.position);
            damageable.TakeDamage();
            StartCoroutine(DelayedStateChange(PatrolEnemyState.isBackingToPatrol));
        }
        else StartCoroutine(DelayedStateChange(PatrolEnemyState.isBackingToPatrol));
    }
    IEnumerator DelayedStateChange(PatrolEnemyState _state)
    {
        yield return new WaitForSeconds(1f);
        state = _state;
    }
    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        if (damageable != null)
        {
            if (level > damageable._level && damageable._isAlive)
            {
                target = collision.transform;
                AttackOnCollision();


            }

        }

    }
    public override void AttackOnCollision()
    {
        state = PatrolEnemyState.isAttacking;
        Vector3 dirV = (target.position - transform.position).normalized;
        Quaternion lookDirection = Quaternion.LookRotation(dirV);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookDirection, 360);
    }
}
