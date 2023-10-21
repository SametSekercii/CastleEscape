using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : UnitySingleton<ObjectPooler>
{

    #region deathEffect

    public GameObject deathEffectPrefab;
    public List<GameObject> deathEffectPool;
    private int amountOfDeathEffect = 5;


  

    
    public GameObject GetDeathEffectFromPool()
    {
        for (int i = 0; i < amountOfDeathEffect; i++)
        {
            if (!deathEffectPool[i].activeSelf) return deathEffectPool[i];
        }
        return null;
    }

    public void CreateDeathEffectPool()
    {
        for (int i = 0; i < amountOfDeathEffect; i++)
        {
            var deathEffect = Instantiate(deathEffectPrefab);
            deathEffect.transform.SetParent(transform);
            deathEffect.SetActive(false);
            deathEffectPool.Add(deathEffect);
        }
    }
    #endregion
    private void Start()
    {
        CreateDeathEffectPool();
    }
}
