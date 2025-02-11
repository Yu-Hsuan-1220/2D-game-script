using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class enermy : MonoBehaviour
{
    
    [SerializeField] float health;
    [SerializeField] float damage;
    [SerializeField] float moveSpeed;
    [SerializeField] float[] damageLevelMul;
    [SerializeField] float[] healthLevelMul;
    [SerializeField] float vanishDistance;
    [SerializeField] GameObject effectsParent;
    public int level;
    float currentSpeed;
    [SerializeField] float damageRate;
    [SerializeField] GameObject[] Drops;
    GameObject expParents;
    [SerializeField] GameObject bleeding;
    SpriteRenderer graphic;
    Vector2 direction;
    GameObject character;
    bool isFrozen;
    countEnemies countEnemies;
    private void Awake() {
        countEnemies = transform.parent.GetComponent<countEnemies>();
        effectsParent = GameObject.Find("special effect");
        level = 1;
        graphic = GetComponent<SpriteRenderer>();
        character = GameObject.Find("character1");
        expParents = GameObject.Find("expParents");
        currentSpeed = moveSpeed;
    }
    
    void FixedUpdate(){
        updateWalkDirection();
        if(!isFrozen) move();
        if(Vector3.Distance(transform.position, character.transform.position)> vanishDistance){
            countEnemies.enemyNum --;
            Destroy(transform.gameObject);
        }
    }
    public void changeLevel(){
        damage*= damageLevelMul[level-1];
        health*= healthLevelMul[level-1];
    }
    void updateWalkDirection(){
        direction = character.transform.position - transform.position;
        if(direction.x < 0){
            graphic.flipX = true;
        }
        else{
            graphic.flipX = false;
        }
    }
    void move(){
        transform.Translate(direction.normalized * currentSpeed * Time.deltaTime);
    }    
    //enemy damaged and enemies' dead
    public void damaged(float Damage){
        health -= Damage;
        Instantiate(bleeding, transform.position, Quaternion.identity, effectsParent.transform);
        if(health < 0){
            enermyDied();
        }
    }
    void enermyDied(){
        int RandomIndex = UnityEngine.Random.Range(0, Drops.Length);
        Instantiate(Drops[RandomIndex], transform.position, Quaternion.identity, expParents.transform);
        Destroy(transform.gameObject);
        countEnemies.enemyNum --;
        
    }

    //damage player
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.GetComponent<playerMovement>()){
            damagePlayer();
            InvokeRepeating(nameof(damagePlayer), damageRate, damageRate);
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.GetComponent<playerMovement>()){
            CancelInvoke(nameof(damagePlayer));
        }
    }
    void damagePlayer(){
        character.GetComponent<playeStatus>().damaged(damage);
    }
    //cry
    float cryDamage;
    public void onCry(float damage, float damageCoolDown, float slowMultiplier){
        currentSpeed *= slowMultiplier;
        cryDamage = damage;
        InvokeRepeating(nameof(helpCallCryDamaged), 0f, damageCoolDown);
    }
    public void leaveCry(){
        currentSpeed = moveSpeed;
        CancelInvoke(nameof(helpCallCryDamaged));
    }
    void helpCallCryDamaged(){
        damaged(cryDamage);
    }

    // bell
    public void freeze(float time){
        isFrozen = true;
        Invoke(nameof(resetFrozen), time);
    }
    void resetFrozen(){
        isFrozen = false;
    }

    //snow ball
    public float snowDamage;
    public void onSnow(float damage, float slowRate, float damageCoolDown){
        snowDamage = damage;
        currentSpeed *= slowRate;
        InvokeRepeating(nameof(helpCallSnowDamage), damageCoolDown, damageCoolDown);
    }
    public void leaveSnow(){
        currentSpeed = moveSpeed;
        CancelInvoke(nameof(helpCallSnowDamage));
    }
    void helpCallSnowDamage(){
        damaged(snowDamage);
    }
    // fireLand
    public float fireDamage;
    public float fireLastTime;
    [SerializeField] GameObject flame;
    GameObject flameOnEnemy;
    public void onFire(float damage, float damageCoolDown, float fireLastTime){
        fireDamage = damage;
        this.fireLastTime = fireLastTime;
        fireGoOut();
        flameOnEnemy = Instantiate(flame, transform.position, Quaternion.identity, transform);
        InvokeRepeating(nameof(fireDamaging), damageCoolDown,damageCoolDown);
    }   
    public void leaveFire(){
        Invoke(nameof(fireGoOut),fireLastTime);
    }
    void fireDamaging(){
        damaged(fireDamage);
    }  
    void fireGoOut(){
        Destroy(flameOnEnemy);
        CancelInvoke(nameof(fireDamaging));
    }
}
