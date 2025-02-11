using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item4Controller : MonoBehaviour
{
    int level;
    [SerializeField] float throwCooldown;
    [SerializeField] float[] damageLevel;
    [SerializeField] GameObject item4Obj;
    Vector2[] direction;
    levelController levelController;
    private void Awake() {
        levelController = transform.parent.GetComponent<levelController>();
        direction = new Vector2[5];
        
    }
    public void change(){
        level = levelController.itemsLV[4];
        float Angle = 90 * Mathf.Deg2Rad;
        float dividedAngle = 2*Mathf.PI / level;
        for(int i=0; i<level; i++){
            direction[i] = new Vector2(Mathf.Cos(Angle), Mathf.Sin(Angle));
            Angle += dividedAngle;
        }
        if(level == 1) InvokeRepeating(nameof(throwItem4), throwCooldown, throwCooldown);
    }
    void throwItem4(){
        for(int i=0; i<level; i++){
            GameObject tmp = Instantiate(item4Obj, levelController.character.transform.position, Quaternion.identity, transform);
            tmp.GetComponent<item4>().direction = direction[i];
            tmp.GetComponent<item4>().damage = damageLevel[level-1];
        }
    }
}
