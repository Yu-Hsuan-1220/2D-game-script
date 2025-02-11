using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class pistle : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    GameObject character;
    GameObject allTmpBullet;
    [SerializeField] private float shootCoolDown;
    [SerializeField] private int magazine;
    
    private int remainBullet;
    private int remainMagzine;
    public Vector2 mousePos;
    private bool readyToShoot;
    public bool isAutomatic;
    private bool isShotting;
    public float recoilDegree;
    public bool isShutgun;
    public float shutGunAngle;
    private void Start() {
        readyToShoot = true;
        character = transform.parent.gameObject;
        allTmpBullet = GameObject.Find("bullet");
    }
    private void Update(){
       mousePos = character.GetComponent<weapencontroller>().mousePos;
    }
    private void shoot(){
       Vector2 direction = Camera.main.ScreenToWorldPoint(mousePos) - transform.position;
       float angle = Mathf.Atan2(direction.y, direction.x)* Mathf.Rad2Deg;
       float randomRecoil = Random.Range(-recoilDegree, recoilDegree);
       angle += randomRecoil;
       Quaternion rotation = Quaternion.AngleAxis(angle, transform.forward);
       GameObject newBullet = Instantiate(bullet, transform.position, rotation, allTmpBullet.transform);
       angle = angle * Mathf.Deg2Rad;
       direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
       newBullet.GetComponent<pistelBullet>().direction = direction;
       if(isShutgun){
            angle = angle * Mathf.Rad2Deg;
            angle -= 2*shutGunAngle;
            for(int i=0; i<5; i++){
                if(i==2){
                    angle += shutGunAngle;
                    continue;
                }
                
                newBullet = Instantiate(bullet, transform.position, Quaternion.identity, allTmpBullet.transform);
                angle = angle * Mathf.Deg2Rad;
                direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                newBullet.GetComponent<pistelBullet>().direction = direction;
                angle = angle * Mathf.Rad2Deg;
                angle += shutGunAngle;
            }
       }
    }
    private void resetShoot(){
        readyToShoot = true;
    }
    public void leftClick(InputAction.CallbackContext ctx){
        if(ctx.performed && readyToShoot && !isAutomatic){
            shoot();
            readyToShoot = false;
            Invoke(nameof(resetShoot), shootCoolDown);
        }
        else if(ctx.started && readyToShoot && isAutomatic){
            isShotting = true;
            InvokeRepeating(nameof(shoot), 0f, shootCoolDown);
        }
        else if(isShotting && ctx.canceled){
            CancelInvoke(nameof(shoot));
        }
    }
    
}
