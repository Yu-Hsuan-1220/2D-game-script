using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class item2 : MonoBehaviour
{
    public float damage;
    public float explodeRadius;
    public bool isDeployed;
    GameObject[] allEnermys;
    public Vector2 destination;
    [SerializeField] float throwSpeed;
    public GameObject explosion;
    void FixedUpdate(){
        checkisDeployed();
    }
    void checkisDeployed(){
        Vector3 dis = new Vector3(destination.x, destination.y, 0f) - transform.position;
        if(dis.magnitude < throwSpeed*Time.deltaTime){
            isDeployed = true;
            return;
        }
        else{
            isDeployed = false;
            transform.Translate(dis.normalized * throwSpeed * Time.deltaTime);
        }

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(isDeployed){
            allEnermys = GameObject.FindGameObjectsWithTag("enermy");
            for(int i=0; i<allEnermys.Length; i++){
                if(Vector3.Distance(allEnermys[i].transform.position, transform.position) <= explodeRadius){
                    allEnermys[i].GetComponent<enermy>().damaged(damage);
                }
            }
            Instantiate(explosion, transform.position, Quaternion.identity, transform.parent);
            Destroy(transform.gameObject);
        }    
    }
}
