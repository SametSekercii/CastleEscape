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
    [SerializeField] private TMP_Text playerLevel;
    
    

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
        TextCheck();

    }
   

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnEscape, OnEscape);
        EventManager.AddHandler(GameEvent.OnFail, OnEscape);
        EventManager.AddHandler(GameEvent.OnCollectKey, OnCollectKey);
        EventManager.AddHandler(GameEvent.OnCollectBook, OnCollectBook);

    }

    

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnEscape, OnEscape);
        EventManager.RemoveHandler(GameEvent.OnFail, OnEscape);
        EventManager.RemoveHandler(GameEvent.OnCollectKey,OnCollectKey);
        EventManager.RemoveHandler(GameEvent.OnCollectBook, OnCollectBook);

    }
    private void TextCheck()
    {
        playerLevel.text = "LV." + gameData.playerLevel.ToString();
    }

    private void OnEscape()
    {
        OpenPanel(winPanel,"SoundPanelPop");
        DisableJoyStick();
        gameData.gameLevel += 1;
        gameData.playerLevel = 1;
    }
    private void OnFail()
    {
        OpenPanel(failPanel, "SoundPanelPop");
        DisableJoyStick();
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
        SceneManager.LoadScene(gameData.gameLevel);

    }
    private void OnCollectKey(object keyIcon)
    {
        GameObject _keyIcon = (GameObject)keyIcon;
        var icon =Instantiate(_keyIcon, transform);
        icon.transform.position = transform.position;
        KeyIconPlacer(icon);

    }
    private void OnCollectBook()
    {
        playerLevel.text ="LV."+ gameData.playerLevel.ToString();
    }
    private void KeyIconPlacer(GameObject keyIcon)
    {
        keyIcon.transform.DOMove(keySlots[keysInSlot].transform.position, 1.2f);
        keysInSlot++;

    }

    
    


}
