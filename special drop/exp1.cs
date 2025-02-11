using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exp1 : MonoBehaviour
{
    [SerializeField]public float expLevel;
    GameObject character;
    
    [SerializeField] bool expCollector;
    [SerializeField] float showRadius;
    public bool isShowing;
    float speed = 20;
    private void Awake() {
        character = GameObject.Find("character1");
    }
    private void FixedUpdate() {
        if(isShowing){
            Vector2 direction = character.transform.position - transform.position;
            if(direction.magnitude < 0.3){
                character.gameObject.GetComponent<playeStatus>().getExp(expLevel);
                Destroy(transform.gameObject);
            }
            transform.position = transform.position + new Vector3(direction.normalized.x, direction.normalized.y, 0f)*speed*Time.deltaTime;
        }    
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<playerMovement>()){
            if(!expCollector){
                other.gameObject.GetComponent<playeStatus>().getExp(expLevel);
                Destroy(transform.gameObject);       
            }
            else{
                GameObject[] allExp= GameObject.FindGameObjectsWithTag("exp");
                for(int i=0; i<allExp.Length; i++){
                    if(Vector3.Distance(transform.position, character.transform.position) < showRadius){
                        allExp[i].GetComponent<exp1>().isShowing = true;
                    }
                    else{
                        other.gameObject.GetComponent<playeStatus>().getExp(allExp[i].GetComponent<exp1>().expLevel);
                        Destroy(allExp[i]);
                    }
                }
                Destroy(transform.gameObject);
            }
        }
        
    }
    
}
