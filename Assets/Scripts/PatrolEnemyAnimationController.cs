using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GuardEnemy;
using static PatrolEnemy;

public class PatrolEnemyAnimationController 
{

    private Animator animator;

    public PatrolEnemyAnimationController(Animator animator)
    {
        this.animator = animator;
    }
    public void SetAnimations(PatrolEnemyState state)
    {
        if (state == PatrolEnemyState.isAttacking)
        {
            animator.SetBool("isWaiting", false);
            animator.SetBool("isMoving", false);
            animator.SetBool("isAttacking", true);
        }
        if (state == PatrolEnemyState.isPatrolling || state==PatrolEnemyState.isBackingToPatrol)
        {
            animator.SetBool("isWaiting", false);
            animator.SetBool("isMoving", true);
            animator.SetBool("isAttacking", false);
        }
        if (state == PatrolEnemyState.isChargingTarget)
        {
            animator.SetBool("isWaiting", false);
            animator.SetBool("isMoving", true);
            animator.SetBool("isAttacking", false);
        }
        if (state == PatrolEnemyState.isDead)
        {
            animator.SetBool("isGuarding", false);
            animator.SetBool("isMoving", false);
            animator.SetBool("isAttacking", false);
            animator.SetBool("isDead", true);


        }
    }
}

