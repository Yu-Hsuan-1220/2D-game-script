using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class chest : MonoBehaviour
{
    [SerializeField] SpriteRenderer image;
    [SerializeField] GameObject[] contains;
    [SerializeField] Sprite chestOpened;
    [SerializeField] float spawnRadius;
    [SerializeField] GameObject expParent;
    bool isOpened;
    private void Awake() {
        image = GetComponent<SpriteRenderer>();
        expParent = GameObject.Find("expParents");
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(!isOpened){
            isOpened = true;
            image.sprite = chestOpened;
            Vector3 direction = other.gameObject.transform.position - transform.position;
            float angleBetween0 = Vector3.Angle(direction, new Vector3(1,0,0));
            float dotValue = Vector3.Dot(direction, new Vector3(0, 1, 0));
            float startAngle;
            if(dotValue>=0) startAngle = angleBetween0 - 120;
            else startAngle = 240 - angleBetween0;
            float dividedAngle = Mathf.PI*2 /3 / (contains.Length - 1);
            startAngle *= Mathf.Deg2Rad;
            for(int i=0; i<contains.Length; i++){
                float x = Mathf.Cos(startAngle);
                float y = Mathf.Sin(startAngle);
                Instantiate(contains[i], other.gameObject.transform.position + new Vector3(x, y, 0)* spawnRadius, Quaternion.identity, expParent.transform);
                startAngle -= dividedAngle;
            }
            Invoke(nameof(deleteObj), 5f);
        }
    }
    void deleteObj(){
        Destroy(transform.gameObject);   
    }
}
