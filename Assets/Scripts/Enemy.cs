using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : Knights,IFieldOfView
{
    public Perspective fieldOfView { get; set; }
    protected NavMeshAgent agent;
    protected float attackRange=2.2f;
    

    public List<Transform> GetVisibleTargets() => fieldOfView.visibleTargets;

    public override void TakeDamage()
    {
        rb.AddForce(-transform.forward+transform.up*2,ForceMode.VelocityChange);
        fieldOfView.enabled = false;
        isAlive = false;
    }
    protected abstract override void Attack();



    
    
}
