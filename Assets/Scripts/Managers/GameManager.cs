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
     
    }
   
    void Start()
    {
        player=FindObjectOfType<PlayerController>().gameObject;
        InvokeRepeating("SaveData", 0.05f, 0.05f);
        EventManager.Broadcast(GameEvent.OnStart);

    }

   
    void Update()
    {
        
    }
    void SaveData()
    {
        SaveManager.SaveData(gameData);
    }

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnEscape, OnEscape);
    }
    private void OnDisable()
    {
        EventManager.AddHandler(GameEvent.OnEscape, OnEscape);
    }
    private void OnEscape()
    {
        gameData.gameLevel++;
    }
}
