using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class tool 
{
    static public float directionToAngleDegree(Vector3 direction){
        float angle = Vector3.Angle(direction, new Vector3(1, 0 , 0));
        float dot = Vector3.Dot(direction, new Vector3(0, 1, 0));
        if(dot < 0){
            return 360 - angle;
        }
        else{
            return angle;
        }
    }
}
