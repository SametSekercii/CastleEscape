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
        guardPointPos = transform.position;
        guardPointRot = transform.localRotation;
        LevelTextInitializer();
        fieldOfView=GetComponent<Perspective>();
        animator =GetComponent<Animator>();
        animationController = new GuardEnemyAnimationController(animator);
    }
    private void Update()
    {
        animationController.SetAnimations(state);

        if (fieldOfView.visibleTargets.Count>0)
        {
            //Debug.Log(Vector3.Distance(transform.position, fieldOfView.visibleTargets[0].position));

            IDamageable target = fieldOfView.visibleTargets[0].GetComponent<IDamageable>();
            if(level>target._level)
            {
                state= GuardEnemyState.isMoving;
                agent.SetDestination(fieldOfView.visibleTargets[0].position);

                if (Vector3.Distance(transform.position, fieldOfView.visibleTargets[0].position) < 1.1f)
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
