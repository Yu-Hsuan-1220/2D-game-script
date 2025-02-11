using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class item1Controller : MonoBehaviour
{
    public float radius;
    public float rotateSpeed;
    GameObject[] item1;
    [SerializeField] float[] damageLevel;
    [SerializeField] GameObject item;
    float[] angles;
    levelController levelController;
    float baseAngle;
    int level;
    void Awake(){
        item1 = new GameObject[5];
        angles = new float[5];
        levelController = transform.parent.GetComponent<levelController>();
    }
    void FixedUpdate(){
        baseAngle -= rotateSpeed* Mathf.Deg2Rad * Time.deltaTime;
        rotate();
    }
    public void change(){
        level = levelController.itemsLV[1];
        for(int i=0; i<level-1; i++){
            Destroy(item1[i]);
        }
        
        float dividedAngle = 2*Mathf.PI / level;
        float spawnAngle = 0;
        for(int i=0; i<level; i++){
            float x = Mathf.Cos(spawnAngle);
            float y = Mathf.Sin(spawnAngle);
            angles[i] = spawnAngle;
            item1[i] = Instantiate(item, levelController.character.transform.position + new Vector3(x, y, 0)*radius,
            Quaternion.identity, levelController.character.transform );
            item1[i].GetComponent<item1>().damage = damageLevel[level-1];
            spawnAngle += dividedAngle;
        }
    }
    void rotate(){
        for(int i=0; i<level; i++){
            float x = Mathf.Cos(baseAngle + angles[i]);
            float y = Mathf.Sin(baseAngle + angles[i]); 
            item1[i].transform.localPosition =  new Vector3(x, y, 0)* radius;
        }
    }
}
