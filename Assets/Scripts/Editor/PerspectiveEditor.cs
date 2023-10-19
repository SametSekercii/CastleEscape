using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Perspective))]
public class PerspectiveEditor : Editor
{
    private void OnSceneGUI()
    {

        Perspective pers = (Perspective)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(pers.transform.position, Vector3.up, Vector3.forward, 360, pers.viewRadius);
        Vector3 viewAngleA = pers.DirFromAngle(pers.viewAngle / 2, false);
        Vector3 viewAngleB = pers.DirFromAngle(-pers.viewAngle / 2, false);

        Handles.DrawLine(pers.transform.position, pers.transform.position + viewAngleA * pers.viewRadius);
        Handles.DrawLine(pers.transform.position, pers.transform.position + viewAngleB * pers.viewRadius);

        Handles.color = Color.red;
        foreach (Transform visibleTarget in pers.visibleTargets)
        {
            Handles.DrawLine(pers.transform.position, visibleTarget.position);
        }

    }
}
