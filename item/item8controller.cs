using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item8controller : MonoBehaviour
{
    [SerializeField] float[] damage;
    [SerializeField] float damageCoolDown;
    [SerializeField] float throwCooldown;
    [SerializeField] float Radius;
    [SerializeField] float existTime;
    [SerializeField] float moveDistance;
    [SerializeField] float fireLastTime;
    [SerializeField] GameObject fireBall;
    levelController levelController;
    int level;
    private void Awake() {
        level = 0;
        levelController = transform.parent.GetComponent<levelController>();
    }
    public void change(){
        level = levelController.itemsLV[8];
        if(level == 1){
            InvokeRepeating(nameof(GenerateFire), 2f, throwCooldown);
        }
    }
    void GenerateFire(){
        float Angle = 180 * Mathf.Deg2Rad;
        float dividedAngle = 2*Mathf.PI / level;
        for(int i=0; i<level; i++){
            Vector2 direction = new Vector2(Mathf.Cos(Angle), Mathf.Sin(Angle));
            Angle += dividedAngle;
            Vector2 startPostion = new Vector2(levelController.character.transform.position.x +Radius * direction.x, levelController.character.transform.position.y + Radius * direction.y + moveDistance);
            GameObject tmp = Instantiate(fireBall, startPostion, Quaternion.identity, transform);
            tmp.GetComponent<item8fireball>().damage = damage[level-1];
            tmp.GetComponent<item8fireball>().damageCoolDown = damageCoolDown;
            tmp.GetComponent<item8fireball>().fireLastTime = fireLastTime;
            tmp.GetComponent<item8fireball>().existTime = existTime;
            tmp.GetComponent<item8fireball>().setDestination(Radius * direction + new Vector2(levelController.character.transform.position.x, levelController.character.transform.position.y));
            
        }
        
    }
}
