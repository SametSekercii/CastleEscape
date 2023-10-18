using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator playerAnimator;
    public PlayerAnimations(Animator playerAnimator)
    {
        this.playerAnimator = playerAnimator;
    }

    

    public void SetAnimations(Vector3 moveVector) 
    {
        if (moveVector.magnitude>0)
        {
            playerAnimator.SetBool("isRun", true);
        }
        else
        {
            playerAnimator.SetBool("isRun", false);
        }
    } 
}
