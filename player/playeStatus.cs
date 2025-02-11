using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class playeStatus : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float playerBasedHealth;
    public float playerMaxHealth;
    public float playerCurHealth;
    public float exp;
    public int level;
    public int[] expNeeded;
    float playerLevel;
    public UnityEvent test;
    private void Start() {
        level = 0;
        playerMaxHealth = playerBasedHealth;
        playerCurHealth = playerBasedHealth;    
    }
    void Update(){
        
    }
    public void damaged(float damaged){
        playerCurHealth -= damaged;
    }
    public void heal(float amount){
        playerCurHealth += amount;
    }
    public void getExp(float num){
        exp+=num;
        if(exp >= expNeeded[level]){
            levelUp();
        }
    }
    void levelUp(){
        exp -= expNeeded[level];
        level++;
        test.Invoke();
    }
}
