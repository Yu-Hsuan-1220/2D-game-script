using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showEnemiesCnt : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] countEnemies countEnemies;
    private void FixedUpdate() {
        text.text = countEnemies.enemyNum.ToString();
    }
}
