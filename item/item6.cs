using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item6 : MonoBehaviour
{
    public float damage;

    public float rotateSpeed;
    public bool rotateClockwise;
    float angle;
    GameObject character;
    private void Awake() {
        angle = 0;
        character = GameObject.Find("character1");
        
    }
    private void FixedUpdate() {
        rotateItem();
        checkOutOfBound();
    }
    void rotateItem(){
        if(rotateClockwise){
            angle -= rotateSpeed* Time.deltaTime;
        }
        else angle += rotateSpeed*Time.deltaTime;
        transform.localRotation = Quaternion.AngleAxis(angle, transform.forward);
    }
    void checkOutOfBound(){
        if(transform.position.y< character.transform.position.y -6f){
            Destroy(transform.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "enermy"){
            other.gameObject.GetComponent<enermy>().damaged(damage);
        }
    }
}
