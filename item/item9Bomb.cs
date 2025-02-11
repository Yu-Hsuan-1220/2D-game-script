using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item9Bomb : MonoBehaviour
{
    bool isDeployed;
    GameObject[] allEnermys;
    public float damage;
    [SerializeField] GameObject explosion;
    public float explodeRadius;
    private void Awake() {
        Invoke(nameof(explode), 2.4f);
    }
    private void explode() {
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
