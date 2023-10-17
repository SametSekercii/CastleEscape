using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Collectable
{
    public Door[] doorsCanUnlock;

    public override void OnCollect()
    {
        UnlockDoors();
        EventManager.Broadcast(GameEvent.OnPlaySound, "SoundCollect");
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
