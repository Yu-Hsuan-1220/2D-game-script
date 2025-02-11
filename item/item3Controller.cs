using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item3Controller : MonoBehaviour
{
    [SerializeField] float[] RadiusLevel;
    [SerializeField] float[] damageLevel;
    [SerializeField] float[] slowMultiplierLevel;
    [SerializeField] GameObject cryObject;
    GameObject ObjectUsing;
    levelController levelController;
    int level;
    private void Awake() {
        levelController = transform.parent.GetComponent<levelController>();
    }
    public void change(){
        level = levelController.itemsLV[3];
        if(level == 1){
            ObjectUsing = Instantiate(cryObject, levelController.character.transform.position + new Vector3(0, -0.5f, 0), 
                                                Quaternion.identity, levelController.character.transform);
        }
        ObjectUsing.GetComponent<item3>().damage = damageLevel[level-1];
        ObjectUsing.GetComponent<item3>().radiusScale = RadiusLevel[level-1];
        ObjectUsing.GetComponent<item3>().slowMultiplier = slowMultiplierLevel[level-1];
        ObjectUsing.GetComponent<item3>().changeScale();

    }
}
