using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public GameData data;

    void Awake()
    {
#if !UNITY_EDITOR
        SaveManager.LoadData(data);
#endif

        SceneLoad();
    }

    void SceneLoad()
    {
        SceneManager.LoadScene(data.gameLevel);
    }
}