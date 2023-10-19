using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController
{
    private Animator playerAnimator;
    public PlayerAnimationController(Animator playerAnimator)
    {
        this.playerAnimator = playerAnimator;
    }



    public void SetAnimations(Vector3 moveVector)
    {
        if (moveVector.magnitude > 0)
        {
            playerAnimator.SetBool("isRun", true);
        }
        else
        {
            playerAnimator.SetBool("isRun", false);
        }
    }

    
}
