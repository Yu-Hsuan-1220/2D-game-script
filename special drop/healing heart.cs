using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healingheart : MonoBehaviour
{
    [SerializeField] float healAmount;

    private void OnTriggerEnter2D(Collider2D other) {
        other.gameObject.GetComponent<playeStatus>().heal(healAmount);
        Destroy(transform.gameObject);
    }
}
