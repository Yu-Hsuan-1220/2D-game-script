using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pistelBullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float flySpeed;
    [SerializeField] float maxDistance;
    [SerializeField] int damage;
    [SerializeField] bool isPenertrate;
    public Vector2 direction;
    void Start(){
        direction = direction.normalized;
        Invoke(nameof(deleteBullet), maxDistance/flySpeed);
    }
    void Update(){
        
        transform.position= transform.position + new Vector3(direction.x, direction.y, 0)* flySpeed * Time.deltaTime;
        
    }
    void deleteBullet(){
        Destroy(transform.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<enermy>()){
            other.gameObject.GetComponent<enermy>().damaged(damage);
            if(!isPenertrate) deleteBullet();            
        }
    }
}
