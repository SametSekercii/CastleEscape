using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class UIManager : UnitySingleton<GameManager>
{
    GameManager gameManager;
    GameData gameData;

    [Space(15)]
    [Header("Definitions")]

    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject failPanel;
    [SerializeField] private GameObject joystick;
    [SerializeField] private TMP_Text gameLevelText;

    [Space(15)]
    [Header("Arrays")]
    [SerializeField] private GameObject[] keySlots;

    [Space(15)]
    [Header("Float&Int")]
    private int keysInSlot = 0;

    private void Awake()
    {   
        gameManager = FindObjectOfType<GameManager>();
        gameData = gameManager.gameData;
        
    }
    
    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnEscape, OnEscape);
        EventManager.AddHandler(GameEvent.OnFail, OnFail);
        EventManager.AddHandler(GameEvent.OnCollectKey, OnCollectKey);
        EventManager.AddHandler(GameEvent.OnStart, OnStart);
    }
    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnEscape, OnEscape);
        EventManager.RemoveHandler(GameEvent.OnFail, OnFail);
        EventManager.RemoveHandler(GameEvent.OnCollectKey, OnCollectKey);
        EventManager.RemoveHandler(GameEvent.OnStart, OnStart);
    }
    private void OnEscape()
    {
        OpenPanel(winPanel,"SoundPanelPop");
       
        DisableJoyStick();
    }
    private void OnFail()
    {
        OpenPanel(failPanel, "SoundPanelPop");
        DisableJoyStick();
    }

    private void OnStart()
    {
        gameLevelText.text ="Level "+gameData.gameLevel.ToString();
    }
    private void DisableJoyStick( )=> joystick.SetActive(false);
    private void OpenPanel(GameObject panel,string sound)
    {
        panel.gameObject.SetActive(true);
        EventManager.Broadcast(GameEvent.OnPlaySound, sound);
    }
    public void Next()
    {
        EventManager.Broadcast(GameEvent.OnPlaySound, "SoundClick");
        if(gameData.gameLevel<=5)
        SceneManager.LoadScene(gameData.gameLevel);
        else
        SceneManager.LoadScene(UnityEngine.Random.Range(1, 6));


    }
    public void Restart()
    {
        EventManager.Broadcast(GameEvent.OnPlaySound, "SoundClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnCollectKey(object keyIcon)
    {
        GameObject _keyIcon = (GameObject)keyIcon;
        var icon =Instantiate(_keyIcon, transform);
        icon.transform.position = transform.position;
        KeyIconPlacer(icon);
    }
    private void KeyIconPlacer(GameObject keyIcon)
    {
        keyIcon.transform.DOMove(keySlots[keysInSlot].transform.position, 1.2f);
        keysInSlot++;
    }

    
    


}
