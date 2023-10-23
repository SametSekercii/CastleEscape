using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeLine : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
          
            EventManager.Broadcast(GameEvent.OnEscape);  
        }
    }
}
