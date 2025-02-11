using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item3 : MonoBehaviour
{
    public float damageCoolDown;
    public float damage;
    public float slowMultiplier;
    public float radiusScale;
    
    public void changeScale(){
        transform.localScale = Vector3.one * radiusScale;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "enermy"){
            other.gameObject.GetComponent<enermy>().onCry(damage, damageCoolDown, slowMultiplier);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "enermy"){
            other.gameObject.GetComponent<enermy>().leaveCry();
        }
    }
}
