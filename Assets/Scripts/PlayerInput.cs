using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public Joystick joystick;
    public Vector3 moveVector { get; private set; }


    

    void Update()
    {
        GetMoveDirectionVector();

    }

    private void GetMoveDirectionVector()
    {
        moveVector = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
    }
     
}
   
