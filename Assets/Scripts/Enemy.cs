using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Knights,IFieldOfView
{
    protected Perspective fieldOfView;
    protected NavMeshAgent agent;
    protected float attackRange=2.2f;

    public List<Transform> GetVisibleTargets() => fieldOfView.visibleTargets;

    public override void TakeDamage()
    {
        isAlive = false;
    }
    
        
   
}
