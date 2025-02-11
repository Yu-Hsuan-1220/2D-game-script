using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    [SerializeField] GameObject character;
    Slider fillSlider;
    playeStatus playerStatus;
    private void Awake() {
        fillSlider = GetComponent<Slider>();
        playerStatus = character.GetComponent<playeStatus>();
    }
    private void Update() {
        fillSlider.maxValue = playerStatus.playerMaxHealth;
        fillSlider.value = playerStatus.playerCurHealth;
    }

}
