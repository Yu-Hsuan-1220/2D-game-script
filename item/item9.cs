using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item9 : MonoBehaviour
{
    [SerializeField] GameObject bomb;
    public float damage;
    public float throwCooldown;
    public float flySpeed;
    GameObject character;
    Vector3 direction;
    public void activate() {
        character = GameObject.Find("character1");
        direction = character.transform.position - transform.position;
        float angle = Vector3.Angle(direction, new Vector3(1, 0 , 0));
        float dot = Vector3.Dot(direction, new Vector3(0, 1, 0));
        if(dot < 0) angle = (360 - angle);
        transform.rotation = Quaternion.AngleAxis(angle, transform.forward);
        InvokeRepeating(nameof(throwBomb), 0, throwCooldown);
    }
    private void FixedUpdate() {
        transform.position = transform.position + (direction.normalized * flySpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position, character.transform.position)> 15){
            Destroy(transform.gameObject);
        }
    }
    void throwBomb(){
        GameObject tmp = Instantiate(bomb, transform.position, Quaternion.identity, transform.parent);
        tmp.GetComponent<item9Bomb>().damage = damage;
    }
}
