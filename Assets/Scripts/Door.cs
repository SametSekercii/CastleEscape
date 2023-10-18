using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isLocked;
    Collider col;


    private void Start()
    {
        col = GetComponent<Collider>();
        if (isLocked)
            col.isTrigger = false;
        else
            col.isTrigger = true;    




    }
    public void Unlock() => col.isTrigger = true;
    
        

    

}
