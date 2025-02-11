using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class weapencontroller : MonoBehaviour
{
    public Vector2 mousePos;
    public GameObject weapon;
    GameObject weaponUsing;
    SpriteRenderer weaponPic, characterPic;
    public Quaternion rotation;
    bool faceEast;
    bool autoAttack;
    Transform closestEnemy;
    GameObject enemyParent;
    private void Start() {
        weaponUsing = Instantiate(weapon, transform.position+ (faceEast?  new Vector3(0.6f, 0, 0): new Vector3(-0.6f, 0, 0)), Quaternion.identity, transform);
        weaponPic = weaponUsing.GetComponent<SpriteRenderer>();
        characterPic = GetComponent<SpriteRenderer>();
        autoAttack = true;
        enemyParent = GameObject.Find("enermies");
        //InvokeRepeating(nameof(TrackClosestEnemy), 0.5f, 0.5f);
    }
    private void Update(){
        //if(!autoAttack){
            faceEast = mousePos.x > Screen.width/2;
            rotateImp();
            aimToCursor();
        /*
        }
        else{
            if(closestEnemy != null){
                faceEast = closestEnemy.position.x > Screen.width/2;
                rotateImp();
                aimToClosestEnemy();
            }
        }*/
    }
    void TrackClosestEnemy(){
        int childCnt = enemyParent.transform.childCount;
        float min = 100;
        for(int i=0; i<childCnt; i++){
            float dis = Vector3.Distance(enemyParent.transform.GetChild(i).position, transform.position);  
            if(dis < min){
                min = dis;
                closestEnemy = enemyParent.transform.GetChild(i);
            }    
        }
    }
    private void rotateImp(){
        if(!faceEast){
            characterPic.flipX = true;
            weaponPic.flipY = true;
        }
        else if(faceEast){
            characterPic.flipX = false;
            weaponPic.flipY = false;
        }
    }
    private void aimToCursor(){
        weaponUsing.transform.position = transform.position+ (faceEast?  new Vector3(0.6f, 0, 0): new Vector3(-0.6f, 0, 0)); 
        Vector2 direction = Camera.main.ScreenToWorldPoint(mousePos) - weaponUsing.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        weaponUsing.transform.rotation = rotation;
    }
    void aimToClosestEnemy(){
        weaponUsing.transform.position = transform.position+ (faceEast?  new Vector3(0.6f, 0, 0): new Vector3(-0.6f, 0, 0)); 
        Vector2 direction = closestEnemy.position - weaponUsing.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        weaponUsing.transform.rotation = rotation;
    }
    public void getMousePlacement(InputAction.CallbackContext ctx){
        mousePos = ctx.ReadValue<Vector2>();
        
    }
    public void changeWeapon(GameObject newWeapon){
        Destroy(weaponUsing);
        weaponUsing = Instantiate(newWeapon, transform.position+ (faceEast?  new Vector3(0.6f, 0, 0): new Vector3(-0.6f, 0, 0)), Quaternion.identity, transform);
        weaponPic = weaponUsing.GetComponent<SpriteRenderer>();
    }
}
