using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : Item, ICollectables
{

    public int levelUpAmount;


    public void OnCollect()
    {
        EventManager.Broadcast(GameEvent.OnPlaySound, "SoundCollect");
        LevelUp();
        gameObject.SetActive(false);
    }

    private void LevelUp()
    {
        GameManager.Instance.gameData.playerLevel += levelUpAmount;
    }
}
