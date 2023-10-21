using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public abstract class Knights : MonoBehaviour,IDamageable,IAttacker
{
   
    public bool isAlive = true;
    public int level;
    public float moveSpeed;
    public TMP_Text levelText;
    protected Transform target;


    protected Rigidbody rb;
    protected Animator animator;
   
    public int _level { get { return level; } set { value = level; } }
    public bool _isAlive { get { return isAlive; } set { value = isAlive; } }

    public abstract void TakeDamage();

    public abstract void Hit();
    public abstract void AttackOnCollision();
    protected void SetSeenTarget(Transform _target)
    {
        target = _target;
    }

    
    //public void LookAtTargetAttacking(Transform target)
    //{
    //    StartCoroutine(LookAtTargetAttackingCoroutine(target));
    //}
    //IEnumerator LookAtTargetAttackingCoroutine(Transform target)
    //{

    //    while (state == GuardEnemyState.isAttacking)
    //    {
    //        Vector3 dirV = (target.position - transform.position).normalized;
    //        Quaternion lookDirection = Quaternion.LookRotation(dirV);
    //        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookDirection, 240f * Time.deltaTime);


    //        yield return null;
    //    }

    //    yield return null;
    //}
    protected void LevelTextInitializer() =>levelText.text="LV."+level.ToString();

    
}
