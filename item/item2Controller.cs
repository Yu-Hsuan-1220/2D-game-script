using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item2Controller : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] float throwCoolDown;
    [SerializeField] float[] damageLevel;
    [SerializeField] GameObject item;
    Vector2[] distination;
    levelController levelController;
    int level;
    void Awake(){
        levelController = transform.parent.GetComponent<levelController>();
    }
    public void change(){
        CancelInvoke(nameof(DeployeLandmine));
        level = levelController.itemsLV[2];
        InvokeRepeating(nameof(DeployeLandmine), 1f, throwCoolDown);
    }
    void DeployeLandmine(){
        float dividedAngle = 2*Mathf.PI / level;
        float spawnAngle = 0;
        for(int i=0; i<level; i++){
            float x = Mathf.Cos(spawnAngle);
            float y = Mathf.Sin(spawnAngle);
            GameObject tmp = Instantiate(item, levelController.character.transform.position, Quaternion.identity, transform);
            tmp.GetComponent<item2>().destination = new Vector2(levelController.character.transform.position.x,  levelController.character.transform.position.y)
                                                    + new Vector2(x, y)* radius;
            tmp.GetComponent<item2>().damage = damageLevel[level-1];
            spawnAngle += dividedAngle;
        }
    }
    
}
