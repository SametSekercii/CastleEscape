using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perspective : Sense
{

    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    public List<Transform> visibleTargets= new List<Transform>();

    public override void InitializeSense()
    {
        StartCoroutine("FindTargetWithDelay", 0.7f);
        

    }

    public override void UpdateSense()
    {
        
       
    }
    IEnumerator FindTargetWithDelay(float delay)
    {
        while (true) 
        {
            yield return null;
            FindVisibleTargets();

        }
    }
    void FindVisibleTargets()
    {
        visibleTargets.Clear();
        Collider[] targetInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        for(int i = 0; i < targetInViewRadius.Length; i++) 
        {
            Transform target = targetInViewRadius[i].transform;
            Vector3 dirVToTarget = (target.position - transform.position).normalized;
            if(Vector3.Angle(transform.forward, dirVToTarget)<viewAngle/2)
            {
                float distBetTarget = Vector3.Distance(transform.position, target.position);
                if(!Physics.Raycast(transform.position,dirVToTarget,distBetTarget,obstacleMask))
                {
                    visibleTargets.Add(target);
                }
            }
        }

    }
    public Vector3 DirFromAngle(float AngleInDegrees,bool angleIsGlobal)
    {
        if (!angleIsGlobal) AngleInDegrees += transform.eulerAngles.y;

        return new Vector3(Mathf.Sin(AngleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(AngleInDegrees * Mathf.Deg2Rad));
    }
}

