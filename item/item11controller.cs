using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class item11controller : MonoBehaviour
{
    [SerializeField] float[] throwCooldownlevel;
    [SerializeField] float spawnCooldown;
    [SerializeField] GameObject tower;
    int level;
    levelController levelController;
    GameObject character;
    private void Awake() {
        levelController = transform.parent.GetComponent<levelController>();
        character = levelController.character;
    }
    public void change(){
        level = levelController.itemsLV[11];
        if(level == 1){
            InvokeRepeating(nameof(spawn), 2, spawnCooldown);
        }
    }
    void spawn(){
        Vector3 randomPoint = Random.insideUnitCircle * 5; 
        GameObject tmp = Instantiate(tower, character.transform.position+ randomPoint, Quaternion.identity, transform);
        tmp.GetComponent<item11tower>().throwCooldown = throwCooldownlevel[level-1];
        tmp.GetComponent<item11tower>().init();
    }
}
