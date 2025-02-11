using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UIElements;

public class mapInit : MonoBehaviour
{
    [SerializeField]
    GameObject[] decorations;
    [SerializeField]
    float mapWidth, mapHeight;
    // [SerializeField] GameObject spawnPointsParent;
    // [SerializeField] int numberOfSpawnPoints;
    // [SerializeField] int spawnPointsRadius;
    // [SerializeField] GameObject spawnPoint;
    
    private int numDecoration = 400;
    private void Awake() {
        
        for(int i=0; i<numDecoration; i++){
            float randomX = Random.Range(-mapWidth/2, mapWidth/2);
            float randomY = Random.Range(-mapHeight/2, mapHeight/2);
            int randomIndex = Random.Range(0, decorations.Length);
            Vector3 spawnPostion = new Vector3(randomX, randomY, 0);
            Instantiate(decorations[randomIndex], spawnPostion, Quaternion.identity, transform);
        }
        
        // for(int i=0; i<numberOfSpawnPoints; i++){
        //     float segment = 2 * Mathf.PI * i / numberOfSpawnPoints;
        //     Vector2 point = new Vector2(Mathf.Cos(segment), Mathf.Sin(segment)) * spawnPointsRadius;
        //     GameObject tmp = Instantiate(spawnPoint, point, Quaternion.identity, spawnPointsParent.transform);
        //     if(i%2 == 0){
        //         tmp.GetComponent<spawnEnemy>().stateAwake = 3;
                
        //     }
        // }

    }
    
}
