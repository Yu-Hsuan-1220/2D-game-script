using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class item11 : MonoBehaviour
{
    public float damage;
    public float shootCooldown;
    public float shootRange;
    bool locked;
    GameObject lockedEnemy;
    GameObject[] enemies;
    [SerializeField] GameObject enemyParent;
    [SerializeField] GameObject bullet;
    public void init() {
        enemyParent = GameObject.Find("enermies");
        InvokeRepeating(nameof(shoot), 0.3f, shootCooldown);

    }
    void shoot(){
        if(lockedEnemy == null){ 
            locked = false;
        }
        if(!locked){
            int childCnt = enemyParent.transform.childCount;
            float min = 100;
            for(int i=0; i<childCnt; i++){
                float dis = Vector3.Distance(enemyParent.transform.GetChild(i).position, transform.position);
                
                if(dis < shootRange && dis < min){
                    lockedEnemy = enemyParent.transform.GetChild(i).gameObject;
                    min = dis;
                    locked = true;
                }    
            }
            
        }
        if(locked){
            Vector3 direction = lockedEnemy.transform.position - transform.position;
            float angle = tool.directionToAngleDegree(direction);
            Quaternion rotation = Quaternion.AngleAxis(angle, transform.forward);
            transform.rotation = rotation;
            GameObject tmp = Instantiate(bullet, transform.position, rotation, transform);
            tmp.GetComponent<pistelBullet>().direction = direction;
            if(Vector3.Distance(transform.position, lockedEnemy.transform.position) > shootRange){
                locked = false;
            }
        }
        
    }
}
