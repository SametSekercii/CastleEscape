using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPath : MonoBehaviour
{


    public Transform[] pathPoints;
    private Vector3[] pathPointsPos;
    public int lenght {  get { return pathPoints.Length; } }

    private void Awake()
    {
        pathPointsPos = new Vector3[pathPoints.Length];

        SetPathPos();
    }

    public Vector3 GetPathPoint(int index) =>pathPointsPos[index];

    public void ReversePath()
    {
        Transform[] reversePath;
        reversePath=new Transform[pathPoints.Length];
        int counter = 0;
        for (int i = pathPoints.Length-1; i >=0;i--) 
        {
            Debug.Log(i);
            reversePath[counter] = pathPoints[i];
            counter++;
        }
        pathPoints = reversePath;
        SetPathPos();    


    }
    private void SetPathPos()
    {
        for (int i = 0; i < pathPoints.Length; i++)
        {
            pathPointsPos[i] = pathPoints[i].position;
        }


    }
    
    
    
      
    




}
