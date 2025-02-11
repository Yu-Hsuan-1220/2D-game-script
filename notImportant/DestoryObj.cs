using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryObj : MonoBehaviour
{
    public float existTime;

    void Awake(){
        Invoke(nameof(delete), existTime);
    }
    void delete(){
        Destroy(transform.gameObject);
    }
}
