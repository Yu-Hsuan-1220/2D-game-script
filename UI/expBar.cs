using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class expBar : MonoBehaviour
{
    [SerializeField] GameObject character;
    Slider fillSlider;
    playeStatus playerStatus;

    void Start(){
        fillSlider = GetComponent<Slider>();
        playerStatus = character.GetComponent<playeStatus>();
    }
    void Update()
    {
        fillSlider.maxValue = playerStatus.expNeeded[playerStatus.level];
        fillSlider.value = playerStatus.exp;
    }
}
