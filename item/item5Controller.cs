using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item5Controller : MonoBehaviour
{
    int level;
    [SerializeField] float throwCooldown;
    [SerializeField] float[] damageLevel;
    [SerializeField] GameObject item5Obj;
    Vector2[] direction;
    levelController levelController;
    private void Awake() {
        levelController = transform.parent.GetComponent<levelController>();
        direction = new Vector2[5];
        
    }
    public void change(){
        level = levelController.itemsLV[5];
        float Angle = 90 * Mathf.Deg2Rad;
        float dividedAngle = 2*Mathf.PI / level;
        for(int i=0; i<level; i++){
            direction[i] = new Vector2(Mathf.Cos(Angle), Mathf.Sin(Angle));
            Angle += dividedAngle;
        }
        if(level == 1) InvokeRepeating(nameof(throwItem5), throwCooldown, throwCooldown);
    }
    void throwItem5(){
        for(int i=0; i<level; i++){
            GameObject tmp = Instantiate(item5Obj, levelController.character.transform.position, Quaternion.identity, levelController.character.transform);
            tmp.GetComponent<item5>().direction = direction[i];
            tmp.GetComponent<item5>().damage = damageLevel[level-1];
        }
    }
}
