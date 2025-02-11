using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLevel : MonoBehaviour
{
    [SerializeField] public string[] title;
    public int[] levels;
    private void Awake() {
        levels = new int[title.Length];
        for(int i=0; i<levels.Length; i++){
            levels[i] = 0;
        }
    }
    
}
