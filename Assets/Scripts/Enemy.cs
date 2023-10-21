using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : Knights,IFieldOfView
{
    public Perspective fieldOfView { get; set; }
    protected NavMeshAgent agent;
    protected float attackRange=2.2f;
    protected float deathDelay = 1.3f;
    

    public List<Transform> GetVisibleTargets() => fieldOfView.visibleTargets;

    public override void TakeDamage()
    {
        
        StartCoroutine(OnDeath());

    }
    public abstract override void Hit();
    public abstract override void AttackOnCollision();

    IEnumerator OnDeath()
    {
        isAlive = false;
        rb.AddForce(-transform.forward + transform.up * 2, ForceMode.VelocityChange);
        yield return new WaitForSeconds(deathDelay);
        transform.gameObject.SetActive(false);
        EffectPlacer.Instance.CreateDeathEffect(transform);
    }



    
    
}
