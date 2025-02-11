using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item8 : MonoBehaviour
{
    public float damage;
    public float damageCoolDown;
    public float fireLastTime;
    public void Timer(float existTime){
        Invoke(nameof(DeleteObj), existTime);
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "enermy"){
            other.gameObject.GetComponent<enermy>().onFire(damage, damageCoolDown, fireLastTime);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "enermy"){
            other.gameObject.GetComponent<enermy>().leaveFire();
        }
    }
    void DeleteObj(){
        Destroy(transform.gameObject);
    }
}
