using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GuardEnemy;

public class GuardEnemyAnimationController
{
    private Animator animator;

    public  GuardEnemyAnimationController(Animator animator)
    {
        this.animator = animator;
    }
    public void SetAnimations(GuardEnemyState state)
    {
        if (state == GuardEnemyState.isAttacking)
        {
            animator.SetBool("isGuarding", false);
            animator.SetBool("isMoving", false);
            animator.SetBool("isAttacking",true);
        }
        if (state == GuardEnemyState.isObservering)
        {
            animator.SetBool("isGuarding", true);
            animator.SetBool("isMoving", false);
            animator.SetBool("isAttacking", false);
        }
        if(state == GuardEnemyState.isChargingTarget ||state== GuardEnemyState.isMovingGuardPoint)
        {
            animator.SetBool("isGuarding", false);
            animator.SetBool("isMoving", true);
            animator.SetBool("isAttacking", false);
        }
        if(state==GuardEnemyState.isDead)
        {
            animator.SetBool("isGuarding", false);
            animator.SetBool("isMoving", false);
            animator.SetBool("isAttacking", false);
            animator.SetBool("isDead", true);


        }
    }
}
