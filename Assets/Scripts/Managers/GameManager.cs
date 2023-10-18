using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : UnitySingleton<GameManager>
{
    public GameData gameData;
    public GameObject player;
    private void Awake()
    {
        Application.targetFrameRate = 60;
        gameData.playerLevel = 1;
    }
   
    void Start()
    {
        player=FindObjectOfType<PlayerController>().gameObject;
        InvokeRepeating("SaveData", 0.05f, 0.05f);

    }

   
    void Update()
    {
        
    }
    void SaveData()
    {
        SaveManager.SaveData(gameData);
    }
}
