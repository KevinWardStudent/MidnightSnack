using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor (typeof(K_AIVision))]
public class K_FieldofViewEditor : Editor
{
    void OnSceneGUI()
    {
        K_AIVision fov = (K_AIVision)target; // We want to inspect the Vision script which will handle the calculations for our AI
        Handles.color = Color.white; // we want our visualized feld of view to be white, so draw the circle with that color
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.fieldOfViewRadius); // Draw an arc at the center of AI, on Y axis, towards Z axis, at limit of field of 
        Vector3 viewAngleA = fov.DirFromAngle(-fov.fieldOfViewAngle/2,false);
        Vector3 viewAngleB = fov.DirFromAngle(fov.fieldOfViewAngle / 2, false);
        //Now we define two point in which to draw the edges of our view radius
        Handles.DrawLine(fov.transform.position,fov.transform.position+viewAngleA * fov.fieldOfViewRadius); // neg dir of half of viewAngle at length of viewRadius from AI pos
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleB * fov.fieldOfViewRadius); // pos direction

        Handles.color = Color.red;
        //Gets list from AI Vision and Find's all targets in list and draws line to them, a debug check
        foreach (Transform visibleTarget in fov.visibleTargets)
        {
            Handles.DrawLine(fov.transform.position, visibleTarget.position);
        }
    }
}
