using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item1 : MonoBehaviour
{
    public float damage;
    
    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.tag == "enermy"){
            other.gameObject.GetComponent<enermy>().damaged(damage);
        }
    }
}
