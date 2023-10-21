using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPlacer : UnitySingleton<EffectPlacer>
{



    public void CreateDeathEffect(Transform _transform)
    {
        var effect = ObjectPooler.Instance.GetDeathEffectFromPool();
        if (effect != null )
        {
            effect.transform.position = _transform.position;
            effect.transform.rotation = _transform.rotation;
            effect.SetActive(true);
        
        }
    }
   



}
