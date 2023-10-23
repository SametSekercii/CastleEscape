using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BigDoorLock : MonoBehaviour
{
    public void Unlock()
    {
        StartCoroutine(UnlockAnimated());

    }

    IEnumerator UnlockAnimated()
    {

        transform.DOMoveX(transform.position.x-3,2.5f).OnComplete(() =>
        {
            gameObject.SetActive(false);
        }); ;
        yield return null;  
    }
}
