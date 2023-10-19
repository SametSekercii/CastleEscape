using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum KnightsState { isAlive,isDead}
public abstract class Knights : MonoBehaviour,IDamageable
{
    public KnightsState knightState=KnightsState.isAlive;
    public int level;
    public TMP_Text levelText;

    protected abstract void Attack(Transform target);
    public void TakeDamage() 
    {
       

    }
    protected void LevelTextInitializer() =>levelText.text="LV."+level.ToString();

    
}
