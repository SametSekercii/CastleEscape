using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public abstract class Knights : MonoBehaviour,IDamageable
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

    protected abstract void Attack();
    protected void SetSeenTarget(Transform _target)
    {
        target = _target;
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        if (damageable != null)
        {
            if (level > damageable._level && damageable._isAlive) Attack();
           
        }

    }
    protected void LevelTextInitializer() =>levelText.text="LV."+level.ToString();

    
}
