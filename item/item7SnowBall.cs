using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item7SnowBall : MonoBehaviour
{
    Vector2 destination;
    bool set;
    [SerializeField] float flySpeed;
    [SerializeField] GameObject snowland;
    public float damage;
    public float damageCoolDown;
    public float slowRate;
    public float existTime;
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
        GameObject tmp = Instantiate(snowland, transform.position, Quaternion.identity ,transform.parent);
        tmp.GetComponent<item7>().damage =damage;
        tmp.GetComponent<item7>().damageCoolDown =damageCoolDown;
        tmp.GetComponent<item7>().slowRate =slowRate;
        tmp.GetComponent<item7>().Timer(existTime);
        Destroy(transform.gameObject);

    }
}
