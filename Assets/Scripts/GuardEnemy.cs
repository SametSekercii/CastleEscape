using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardEnemy : Enemy
{
    public enum GuardEnemyState{isGuarding,isAttacking ,isMoving}

    GuardEnemyState state;
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


    private void Move()
    {

    }
    private void Guard()
    {

    }

    private void SetGuardPointValues()
    {
        guardPointPos = transform.position;
        guardPointRot = transform.localRotation;
    }
    private void Mission()
    {
        if (GetVisibleTargets().Count > 0)
        {
          
            IDamageable target = fieldOfView.visibleTargets[0].GetComponent<IDamageable>();
            if (level > target._level)
            {
                state = GuardEnemyState.isMoving;
                agent.SetDestination(fieldOfView.visibleTargets[0].position);

                if (Vector3.Distance(transform.position, fieldOfView.visibleTargets[0].position) < attackRange)
                {
                    agent.SetDestination(transform.position);
                    state = GuardEnemyState.isAttacking;
                    Attack(target);
                }

            }
        }
        else
        {
            if (Vector3.Distance(transform.position, guardPointPos) < 0.2f)
            {
                transform.rotation = guardPointRot;
                state = GuardEnemyState.isGuarding;
            }
            else
            {
                agent.SetDestination(guardPointPos);
                state = GuardEnemyState.isMoving;

            }
        }

    }

}
