using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject[] enermies;
    GameObject[] enemyCanSpawn;
    int len; 
    GameObject enermyParent;
    private int enermyIndex;
    public int stateAwake;
    int state;
    countEnemies countEnemies;
    void Awake(){
        countEnemies = GameObject.Find("enermies").GetComponent<countEnemies>();
        state = 1;
        enermyParent = GameObject.Find("enermies");
        enemyCanSpawn = new GameObject[10];
        enemyCanSpawn[0] = enermies[0];
        enemyCanSpawn[1] = enermies[1];
        len = 2;
        stateController();
        
    }
    void stateController(){
        Invoke(nameof(nextState), 60f); 
        InvokeRepeating(nameof(spawn), Random.Range(1, 2f), Random.Range(1, 1.9f));
        
    }
    void nextState(){
        state++;
        if(state == 8){
            enemyCanSpawn[2] = enermies[2];
            len++;
        }
        print(state);
        CancelInvoke(nameof(spawn));
        stateController();
    }
    void spawn(){
        if(state >= stateAwake && countEnemies.enemyNum < transform.parent.GetComponent<spawncontroller>().spawnMaxForState[state]){
            enermyIndex = Random.Range(0, len);
            if(state >= 14){
                enermyIndex = 2;
            }
            countEnemies.enemyNum++;
            GameObject tmp = Instantiate(enemyCanSpawn[enermyIndex], transform.position, Quaternion.identity, enermyParent.transform);
            if(state >= 5 && state <= 7){
                tmp.GetComponent<enermy>().level = 2;
                tmp.GetComponent<enermy>().changeLevel();
            }
            else if(state >= 8 && state <= 10){
                tmp.GetComponent<enermy>().level = 3;
                tmp.GetComponent<enermy>().changeLevel();
            }
            if(state >= 11 && state <= 12){
                tmp.GetComponent<enermy>().level = 4;
                tmp.GetComponent<enermy>().changeLevel();
            }
            if(state >= 13 && state <= 15){
                tmp.GetComponent<enermy>().level = 5;
                tmp.GetComponent<enermy>().changeLevel();
            }
        }
    }
}
