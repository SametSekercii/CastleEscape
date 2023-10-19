using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

    

public class PatrolEnemy : Enemy
{

    public bool isReversePatrol;
    PatrolPath path;
    Vector3 targetPos;
    int index = 0;

    private void Start()
    {
        rb=GetComponent<Rigidbody>();
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
        Move();

        if(Vector3.Distance(transform.position, targetPos)<0.5f)
        {
            SetNewTargetPos();

        }


    }

    private void Move()
    {
        Vector3 dirV=(targetPos-transform.position).normalized;
        rb.MovePosition(rb.position + dirV * Time.deltaTime * moveSpeed);
        transform.forward += dirV;
        //transform.DORotate(dirV+transform.forward,0.5f);
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
