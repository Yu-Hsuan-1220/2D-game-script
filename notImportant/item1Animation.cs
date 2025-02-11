using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item1Animation : MonoBehaviour
{
    public float rotateSpeed;
    float angle;
    void Update()
    {
        angle -= rotateSpeed * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(angle, transform.forward);
    }
}
