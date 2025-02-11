using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item10 : MonoBehaviour
{
    public float damage;
    public float speed;
    float rotateSpeed;
    Vector3 direction;
    GameObject character;
    float angle;
    private void Awake() {
        character = GameObject.Find("character1");
        rotateSpeed = 360;
        direction = new Vector3(1, 1, 0);
        angle = 0;
        InvokeRepeating(nameof(rotate), 0.1f, 0.1f);
    }
    private void FixedUpdate() {
        move();
        checkDirection();
    }
    void rotate(){
        angle -= rotateSpeed;
        Quaternion rotation = Quaternion.AngleAxis(angle*Mathf.Deg2Rad, transform.forward);
        transform.rotation = rotation;
    }
    void move(){
        transform.position = transform.position + direction.normalized * speed * Time.deltaTime;
    }
    void checkDirection(){
        if(transform.position.x > character.transform.position.x + 8 ){
            direction.x = -1;
        }
        else if(transform.position.x < character.transform.position.x - 8){
            direction.x = 1;
        }
        if(transform.position.y > character.transform.position.y + 4){
            direction.y = -1;
        }
        else if(transform.position.y < character.transform.position.y - 4){
            direction.y = 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        other.gameObject.GetComponent<enermy>().damaged(damage);
    }
}
