using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    [SerializeField]
    GameObject character;
    private void Update() {
        transform.position = character.transform.position + new Vector3(0, 0, -10);
    }
    
}
