using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Knights : MonoBehaviour
{

    public int level;
    public TMP_Text levelText;



  



    protected abstract void Attack();
    

    

    protected void LevelTextInitializer() =>levelText.text="LV."+level.ToString();
    

    


}
