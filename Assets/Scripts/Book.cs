using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : Collectable
{

    public int levelUpAmount;


    public override void OnCollect()
    {
        EventManager.Broadcast(GameEvent.OnPlaySound, "SoundCollect");
        LevelUp();
        gameObject.SetActive(false);
        EventManager.Broadcast(GameEvent.OnCollectBook);
    }

    private void LevelUp()
    {
        GameManager.Instance.gameData.playerLevel += levelUpAmount;
    }
}
