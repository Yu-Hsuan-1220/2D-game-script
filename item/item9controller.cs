using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.Collections;
using UnityEngine;

public class item9controller : MonoBehaviour
{
    [SerializeField] float[] damageLevel; 
    [SerializeField] float[] throwCooldownLevel;
    levelController levelController;
    [SerializeField] float spawnRadius;
    [SerializeField] float spawnCooldown;
    [SerializeField] int level;
    [SerializeField] GameObject plane;
    private void Awake() {
        levelController = transform.parent.GetComponent<levelController>();
        
    }
    public void change(){
        level = levelController.itemsLV[9];
        if(level == 1){
            InvokeRepeating(nameof(spawnPlane), 1f, spawnCooldown);
        }   
    }
    void spawnPlane(){
        float angle = Random.Range(0, 2*Mathf.PI);
        float x = Mathf.Cos(angle);
        float y = Mathf.Sin(angle);
        GameObject tmp = Instantiate(plane, levelController.character.transform.position + new Vector3(x, y, 0f) *spawnRadius, Quaternion.identity, transform);
        tmp.GetComponent<item9>().damage = damageLevel[level-1];
        tmp.GetComponent<item9>().throwCooldown = throwCooldownLevel[level-1];
        tmp.GetComponent<item9>().activate();
    }
}
