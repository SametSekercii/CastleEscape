using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Key : Collectable
{
    public Door[] doorsCanUnlock;
    public GameObject icon;

    public override void OnCollect()
    {
        UnlockDoors();
        EventManager.Broadcast(GameEvent.OnPlaySound, "SoundCollect");
        EventManager.Broadcast(GameEvent.OnCollectKey,icon);
        gameObject.SetActive(false);



    }

    private void UnlockDoors()
    {
        for (int i = 0; doorsCanUnlock.Length > i; i++)
        {
            doorsCanUnlock[i].Unlock();
        }

    }

    

    
}
