using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item10controller : MonoBehaviour
{
    [SerializeField] float[] damageLevel;
    [SerializeField] float[] scale;
    [SerializeField] GameObject spikeBall;
    levelController levelController;
    int level;
    GameObject tmp;
    private void Awake() {
        levelController = transform.parent.GetComponent<levelController>();
    }
    public void change(){
        level = levelController.itemsLV[10];
        if(level == 1){
            tmp = Instantiate(spikeBall, levelController.character.transform.position, Quaternion.identity, transform);
            
        }
        tmp.GetComponent<item10>().damage = damageLevel[level-1];
        tmp.transform.localScale = new Vector3(scale[level-1], scale[level-1], scale[level-1]);
    }
}
