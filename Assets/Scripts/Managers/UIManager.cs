using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : UnitySingleton<GameManager>
{
    GameManager gameManager;
    GameData gameData;

    [Space(15)]
    [Header("Definitions")]

    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject failPanel;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameData = gameManager.gameData;
    }

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnEscape, OnEscape);
        EventManager.AddHandler(GameEvent.OnFail, OnEscape);

    }
    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnEscape, OnEscape);
        EventManager.RemoveHandler(GameEvent.OnFail, OnEscape);

    }

    private void OnEscape()
    {
       
        if (winPanel != null) 
        {
            EventManager.Broadcast(GameEvent.OnPlaySound, "SoundPanelPop");
            winPanel.SetActive(true);

        }

    }
    public void Next()
    {

        EventManager.Broadcast(GameEvent.OnPlaySound, "SoundClick");
        gameData.gameLevel += 1;
        SceneManager.LoadScene(gameData.gameLevel);

    }

    private void OnFail() 
    {
       
        if (failPanel != null)
        {
            EventManager.Broadcast(GameEvent.OnPlaySound, "SoundPanelPop");
            failPanel.SetActive(true);
        }
        
    }
    


}
