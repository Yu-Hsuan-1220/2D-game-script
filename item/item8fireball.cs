using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item8fireball : MonoBehaviour
{
    Vector2 destination;
    bool set;
    [SerializeField] float flySpeed;
    [SerializeField] GameObject fireland;
    public float damage;
    public float damageCoolDown;
    public float existTime;
    public float fireLastTime;
    [SerializeField] GameObject explodeEffect;
    public void setDestination(Vector2 destination){
        this.destination = destination;       
        set = true;
    }
    private void FixedUpdate() {
        if(set){
            transform.Translate(new Vector3(destination.x - transform.position.x, destination.y - transform.position.y, 0).normalized* flySpeed * Time.deltaTime);
            if(Vector3.Distance(transform.position, new Vector3(destination.x, destination.y, 0f)) < 0.1f){
               End();
            }  
        }
    }
    void End(){
        Instantiate(explodeEffect, transform.position, Quaternion.identity, transform.parent);
        GameObject tmp = Instantiate(fireland, transform.position, Quaternion.identity ,transform.parent);
        tmp.GetComponent<item8>().damage =damage;
        tmp.GetComponent<item8>().damageCoolDown =damageCoolDown;
        tmp.GetComponent<item8>().Timer(existTime);
        tmp.GetComponent<item8>().fireLastTime = fireLastTime;
        Destroy(transform.gameObject);

    }
}
