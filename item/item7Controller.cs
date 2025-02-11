using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class item7Controller : MonoBehaviour
{
    [SerializeField] float slowRate;
    [SerializeField] float[] damage;
    [SerializeField] float damageCoolDown;
    [SerializeField] float throwCooldown;
    [SerializeField] float Radius;
    [SerializeField] float existTime;
    [SerializeField] float moveDistance;
    [SerializeField] GameObject snowBall;
    levelController levelController;
    int level;
    private void Awake() {
        level = 0;
        levelController = transform.parent.GetComponent<levelController>();
    }
    public void change(){
        level = levelController.itemsLV[7];
        if(level == 1){
            InvokeRepeating(nameof(GenerateSnow), 2f, throwCooldown);
        }
    }
    void GenerateSnow(){
        float Angle = 0;
        float dividedAngle = 2*Mathf.PI / level;
        for(int i=0; i<level; i++){
            Vector2 direction = new Vector2(Mathf.Cos(Angle), Mathf.Sin(Angle));
            Angle += dividedAngle;
            Vector2 startPostion = new Vector2(levelController.character.transform.position.x +Radius * direction.x, levelController.character.transform.position.y + Radius * direction.y + moveDistance);
            GameObject tmp = Instantiate(snowBall, startPostion, Quaternion.identity, transform);
            tmp.GetComponent<item7SnowBall>().damage = damage[level-1];
            tmp.GetComponent<item7SnowBall>().damageCoolDown = damageCoolDown;
            tmp.GetComponent<item7SnowBall>().slowRate = slowRate;
            tmp.GetComponent<item7SnowBall>().setDestination(Radius * direction + new Vector2(levelController.character.transform.position.x, levelController.character.transform.position.y));
            tmp.GetComponent<item7SnowBall>().existTime = existTime;
        }
        
    }
}
