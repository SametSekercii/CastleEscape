using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

    

public class PatrolEnemy : Enemy
{

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

        targetPos = path.GetPathPoint(0);

    }

    private void FixedUpdate()
    {
        Patrol();

    }


    private void Patrol()
    {
        
        if(Vector3.Distance(transform.position, targetPos)<0.5f)
        {
            SetNewTargetPos();
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
}
