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
    public BigDoorLock[] canOpenLocks;

    

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
        yield return new WaitForSeconds(deathDelay);
        transform.gameObject.SetActive(false);
        UnlockBigDoorLock();
        EffectPlacer.Instance.CreateDeathEffect(transform);
    }
    private void UnlockBigDoorLock()
    {
        if(canOpenLocks.Length > 0)
        {
            for(int i = 0; i < canOpenLocks.Length; i++)
            {
                canOpenLocks[i].Unlock();
            }
        }
    }



    
    
}
