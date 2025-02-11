using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.UI;
public class timer : MonoBehaviour
{
    // Start is called before the first frame update
    int Sec;
    int Min;
    string secString;
    string minString;
    [SerializeField] Text text;
    void Start(){
        Sec = 0;
        Min = 15;
        InvokeRepeating(nameof(plusOneSec), 1f, 1f);
    }
    void plusOneSec(){
        Sec --;
        if(Sec<0){
            Sec += 60;
            Min--;
        }
        convertToText();
    }
    void convertToText(){
        if(Min < 10){
            minString = "0";
        }
        else{
            minString ="";
        }
        if(Sec<10){
            secString = "0";
        }
        else{
            secString = "";
        }
        minString += Min.ToString();
        secString += Sec.ToString();
        text.text = minString + ":" + secString;
    }
}
