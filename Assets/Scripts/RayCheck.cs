using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCheck
{

    //  Check if it's on land 
    public static bool IsOnLand(Transform t, LayerMask layer_mask)
    {
        float length = .25f;

        //  Ray
        Vector3 startPos = t.position - t.up * t.lossyScale.y * .5f;

        Vector3 dir1 = -t.up + t.right;
        Vector3 dir2 = -t.up - t.right;

        Debug.DrawRay(startPos, dir1, Color.red);
        Debug.DrawRay(startPos, dir2, Color.red);
        return Physics.Raycast(startPos, dir1, length, layer_mask)
            || Physics.Raycast(startPos, dir2, length, layer_mask);
    }

    //  Check if X axis in the enterred direction is free
    public static bool IsWallInDir(Transform t, Vector3 direction, LayerMask layer_mask)
    {
        float length = .25f;

        //  Ray
        Vector3 startPos = t.position + direction * t.lossyScale.x * .5f;


        Debug.DrawRay(startPos, direction * .25f, Color.red);
        return Physics.Raycast(startPos, direction, length, layer_mask);
    }




    //  Check if there is Ground on the enterred axis
    public static bool IsGroundInDir(Transform t,Vector3 direction,  LayerMask layer_mask)
    {
        float length = Mathf.Sqrt(Mathf.Pow(t.lossyScale.y, 2) + .25f) + .1f;

        //  Ray
        Vector3 startPos = t.position + direction * t.lossyScale.x * .5f + t.up * t.lossyScale.y * .5f;
        Vector3 dir = (direction * .5f + t.up * -1f).normalized;

        Debug.DrawRay(startPos, dir * length, Color.red);

        return Physics.Raycast(startPos, dir, length, layer_mask);
    }
}
