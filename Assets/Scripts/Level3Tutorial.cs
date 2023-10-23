using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Tutorial : MonoBehaviour
{
    public GameObject book;
    public GameObject collectTheBook;
    public GameObject killEnemy;
    public GameObject unlockDoor;
    public GameObject enemy;
    private bool isBookCollected=false;
    private bool isEnemyKilled=false;

    private void Start()
    {
        StartCoroutine(Level3TutorialCoroutine());
    }

    IEnumerator Level3TutorialCoroutine()
    {
        while (true)
        {

            if (book.activeInHierarchy)
            {
                collectTheBook.SetActive(true);
                killEnemy.SetActive(false);
                unlockDoor.SetActive(false);
            }
            else
            {
                isBookCollected = true;
                collectTheBook.SetActive(false);
                if(!isEnemyKilled) { killEnemy.SetActive(true); }
                unlockDoor.SetActive(true);

            }
            if(!enemy.activeInHierarchy) 
            {
                isEnemyKilled = true;
                unlockDoor.SetActive(false);
                killEnemy.SetActive(false);
            }   
         yield return null;
        }
    }

  
}
