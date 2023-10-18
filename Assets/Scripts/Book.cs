using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : Collectable
{

    public int levelUpAmount;


    public override void OnCollect()
    {
        EventManager.Broadcast(GameEvent.OnPlaySound, "SoundCollect");
 
        gameObject.SetActive(false);
        EventManager.Broadcast(GameEvent.OnCollectBook, levelUpAmount);
    }

  
}
