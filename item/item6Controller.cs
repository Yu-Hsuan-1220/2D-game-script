using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item6Controller : MonoBehaviour
{
    [SerializeField] float thorwForce;
    [SerializeField] float[] damageLevel;
    [SerializeField] float throwCooldown;
    [SerializeField] float horizontalForceRange;
    [SerializeField] GameObject itemObj;
    Vector2 direction;
    levelController levelController;
    int level;

    private void Awake() {
        levelController = transform.parent.GetComponent<levelController>();
        
    }  
    public void change(){
        level = levelController.itemsLV[6];
        if(level == 1){
            InvokeRepeating(nameof(throwObj), throwCooldown, throwCooldown);
        }
    }
    void throwObj(){
        for(int i=0; i<level; i++){
            GameObject tmp = Instantiate(itemObj, levelController.character.transform.position, Quaternion.identity, transform);
            float horizontalForce = Random.Range(-horizontalForceRange, horizontalForceRange);
            tmp.GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontalForce, 1)* thorwForce, ForceMode2D.Impulse);
            tmp.GetComponent<item6>().damage = damageLevel[level-1];
        }
    }
}
