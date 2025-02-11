using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item11tower : MonoBehaviour
{
    [SerializeField] GameObject launcher;
    public float damage;
    public float TowerLastTime;
    public float throwCooldown;
    public void init() {
        GameObject tmp = Instantiate(launcher, transform.position, Quaternion.identity, transform);
        tmp.GetComponent<item11>().shootCooldown = throwCooldown;
        tmp.GetComponent<item11>().init();
        Invoke(nameof(deleteObj), TowerLastTime);
    }
    void deleteObj(){
        Destroy(transform.gameObject);
    }
}
