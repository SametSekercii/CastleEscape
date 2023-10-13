using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioPlay;


    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnPlaySound, OnPlaySound);
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnPlaySound, OnPlaySound);

    }

    private void OnPlaySound(object value)
    {
        string sound = (string)value;
        audioPlay.clip = Resources.Load((string)value) as AudioClip;
        audioPlay.PlayOneShot(audioPlay.clip);
    }


}
