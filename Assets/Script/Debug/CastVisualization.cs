using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastVisualization
{
 
    public static void DrawBoxCast(Vector3 center, Vector3 extents, Vector3 direction,  Quaternion rotation, float distance)
    {

        Vector3[] points = new Vector3[8];

        Vector3 origin2 = center + (direction * distance);

        points[0] = rotation * Vector3.Scale(extents, new Vector3(1, 1, 1)) + origin2;
        points[1] = rotation * Vector3.Scale(extents, new Vector3(1, 1, -1)) + origin2;
        points[2] = rotation * Vector3.Scale(extents, new Vector3(1, -1, 1)) + origin2;
        points[3] = rotation * Vector3.Scale(extents, new Vector3(1, -1, -1)) + origin2;
        points[4] = rotation * Vector3.Scale(extents, new Vector3(-1, 1, 1)) + origin2;
        points[5] = rotation * Vector3.Scale(extents, new Vector3(-1, 1, -1)) + origin2;
        points[6] = rotation * Vector3.Scale(extents, new Vector3(-1, -1, 1)) + origin2;
        points[7] = rotation * Vector3.Scale(extents, new Vector3(-1, -1, -1)) + origin2;

        Debug.DrawLine(points[0], points[1]);
        Debug.DrawLine(points[0], points[2]);
        Debug.DrawLine(points[0], points[4]);

        Debug.DrawLine(points[7], points[6]);
        Debug.DrawLine(points[7], points[5]);
        Debug.DrawLine(points[7], points[3]);

        Debug.DrawLine(points[1], points[3]);
        Debug.DrawLine(points[1], points[5]);

        Debug.DrawLine(points[2], points[3]);
        Debug.DrawLine(points[2], points[6]);

        Debug.DrawLine(points[4], points[5]);
        Debug.DrawLine(points[4], points[6]);
    }

    
}
