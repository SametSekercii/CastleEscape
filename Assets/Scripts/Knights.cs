using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Knights : MonoBehaviour
{
    public int level;
    public TMP_Text levelText;

   





    public void Attack()
    {

    }

    protected void LevelTextInitializer() =>levelText.text="LV."+level.ToString();
    

    


}
