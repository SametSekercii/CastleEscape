using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Item,ICollectables
{
    public Transform[] canUnlock;

    public void OnCollect()
    {
        UnlockDoors();
        EventManager.Broadcast(GameEvent.OnPlaySound, "SoundCollect");
        gameObject.SetActive(false);



    }

    private void UnlockDoors()
    {
        for (int i = 0; canUnlock.Length > i; i++)
        {
            canUnlock[i].GetComponent<Collider>().enabled = false;
        }

    }

    

    
}
