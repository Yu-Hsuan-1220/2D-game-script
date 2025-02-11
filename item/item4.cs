using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item4 : MonoBehaviour
{
    public float damage;
    public float flySpeed;
    public Vector2 direction;
    public float flyDistance;
    public float freezeTime;
    public float rotateSpeed;
    float angle;
    private void Awake() {
        angle = 0;
        Invoke(nameof(deleteObj), flyDistance/flySpeed);
    }
    void deleteObj(){
        Destroy(transform.gameObject);
    }
    private void FixedUpdate() {
        angle += rotateSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.AngleAxis(angle, transform.forward);
        transform.localPosition = transform.localPosition + new Vector3(direction.x, direction.y, 0f)*flySpeed* Time.deltaTime;
    }
    

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.tag == "enermy"){
            other.transform.GetComponent<enermy>().damaged(damage);
            other.transform.GetComponent<enermy>().freeze(freezeTime);
        }
    }
}
