using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class item7 : MonoBehaviour
{
    public float damage;
    public float damageCoolDown;
    public float slowRate;
    public void Timer(float existTime){
        Invoke(nameof(DeleteObj), existTime);
    }
    private void Awake() {
        transform.localScale = new Vector3(2, 2, 2);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "enermy"){
            other.gameObject.GetComponent<enermy>().onSnow(damage, slowRate, damageCoolDown);
            other.gameObject.GetComponent<Animator>().SetBool("Onsnow", true);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "enermy"){
            other.gameObject.GetComponent<enermy>().leaveSnow();
            other.gameObject.GetComponent<Animator>().SetBool("Onsnow", false);
        }
    }
    void DeleteObj(){
        Destroy(transform.gameObject);
    }
}
