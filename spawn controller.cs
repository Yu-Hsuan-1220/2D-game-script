using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawncontroller : MonoBehaviour
{
    GameObject spawnPointsParent;
    [SerializeField] int numberOfSpawnPoints;
    [SerializeField] int spawnPointsRadius;
    [SerializeField] GameObject spawnPointPrefabs;
    GameObject[] spawnPoints;
    [SerializeField] public int[] spawnMaxForState;
    private void Awake() {
        spawnPointsParent = transform.gameObject;
        spawnPoints = new GameObject[numberOfSpawnPoints];
        for(int i=0; i<numberOfSpawnPoints; i++){
            float segment = 2 * Mathf.PI * i / numberOfSpawnPoints;
            Vector2 point = new Vector2(Mathf.Cos(segment), Mathf.Sin(segment)) * spawnPointsRadius;
            spawnPoints[i] = Instantiate(spawnPointPrefabs, point, Quaternion.identity, spawnPointsParent.transform);
            if(i%2 == 0){
                spawnPoints[i].GetComponent<spawnEnemy>().stateAwake = 3;
            }
        }
    }
    
}
