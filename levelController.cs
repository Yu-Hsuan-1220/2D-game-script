using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class levelController : MonoBehaviour
{
    [SerializeField] public GameObject character;
    public int[] itemsLV;
    [SerializeField] GameObject[] weapons;
    [SerializeField] Sprite[] itemImage;
    [SerializeField] Sprite[] basicGunImage;
    [SerializeField] Image[] displayImage;
    [SerializeField] GameObject[] buttoms;
    [SerializeField] GameObject[] background;
    [SerializeField] playerLevel playerLevel;
    weapencontroller weapencontroller;
    
    int[] RandomCanChoose = new int[3];
    int[] itemHasChosen = new int[6];
    int itemHasChosenNum;
    private void Awake() {
        itemHasChosenNum = 0;
        weapencontroller = character.GetComponent<weapencontroller>();
        itemHasChosen[0] = 0;
    }
    public void levelUp(){
        Time.timeScale = 0f;
        
        //check if all item level max
        bool allMax = false;
        if(itemHasChosenNum == 5){
            allMax = true;
            for(int i=0; i<6; i++){
                if(itemsLV[itemHasChosen[i]] != 5){
                    allMax = false;
                    break;
                }
            }
        }
        if(allMax){
            pending();
            return; 
        }
        for(int i=0; i<3; i++){
            int tmpChoice;
            if(itemHasChosenNum < 5){
                tmpChoice = Random.Range(0, itemsLV.Length);
            }
            else{
                tmpChoice = itemHasChosen[Random.Range(0, 6)];
            }
            if(itemsLV[tmpChoice] == 5){
                i-=1;
                continue;
            }
            else{
                RandomCanChoose[i] = tmpChoice;
            }
            //RandomCanChoose[i] =11;
        }
        
        //display on screen
        for(int i=0; i<3; i++){
            buttoms[i].SetActive(true);
            displayImage[i].gameObject.SetActive(true);
            background[i].SetActive(true);
            if(RandomCanChoose[i]==0){
                displayImage[i].sprite = basicGunImage[itemsLV[0]+1];
            }
            else{
                displayImage[i].sprite = itemImage[RandomCanChoose[i]];
            }
        }
    }
    void pending(){
        resumeGame();
    }
    public void buttom1Press(){
        checkIsNewItem(RandomCanChoose[0]);
        itemsLV[RandomCanChoose[0]]++;
        if(RandomCanChoose[0]==0){
            weapencontroller.changeWeapon(weapons[itemsLV[0]-1]);
        }
        else{
            whatTocall(RandomCanChoose[0]);
        }
        resumeGame();
    }
    public void buttom2Press(){
        checkIsNewItem(RandomCanChoose[1]);
        itemsLV[RandomCanChoose[1]]++;
        if(RandomCanChoose[1]==0){
            weapencontroller.changeWeapon(weapons[itemsLV[0]-1]);
        }
        else{
            whatTocall(RandomCanChoose[1]);
        }
        resumeGame();
    }
    public void buttom3Press(){
        checkIsNewItem(RandomCanChoose[2]);
        itemsLV[RandomCanChoose[2]]++;
        if(RandomCanChoose[2]==0){
            weapencontroller.changeWeapon(weapons[itemsLV[0]-1]);
        }
        else{
            whatTocall(RandomCanChoose[2]);
        }
        resumeGame();
    }
    void resumeGame(){
        for(int i=0; i<3; i++){
            buttoms[i].SetActive(false);
            background[i].SetActive(false);
            displayImage[i].gameObject.SetActive(false);
        }
        Time.timeScale = 1f;
    }
    void checkIsNewItem(int index){
        if(itemsLV[index]==0){
            itemHasChosenNum ++;
            itemHasChosen[itemHasChosenNum] = index;
        }
    }
    void whatTocall(int num){
        if(num ==1){
            item1LvUp();
        }
        else if(num == 2){
            item2LvUp();
        }
        else if(num == 3){
            item3LvUp();
        }
        else if(num == 4){
            item4LvUp();
        }
        else if(num==5){
            item5LvUp();
        }
        else if(num==6){
            item6LvUp();
        }
        else if(num==7){
            item7LvUp();
        }
        else if(num==8){
            item8LvUp();
        }
        else if(num==9){
            item9LvUp();
        }
        else if(num == 10){
            item10LvUp();
        }
        else if(num == 11){
            item11LvUp();
        }
    }
    public void item1LvUp(){
        transform.GetChild(0).GetComponent<item1Controller>().change();
    }
    public void item2LvUp(){
        transform.GetChild(1).GetComponent<item2Controller>().change();
    }
    public void item3LvUp(){
        transform.GetChild(2).GetComponent<item3Controller>().change();
    }
    public void item4LvUp(){
        transform.GetChild(3).GetComponent<item4Controller>().change();
    }
    public void item5LvUp(){
        transform.GetChild(4).GetComponent<item5Controller>().change();
    }
    public void item6LvUp(){
        transform.GetChild(5).GetComponent<item6Controller>().change();
    }
    public void item7LvUp(){
        transform.GetChild(6).GetComponent<item7Controller>().change();
    }public void item8LvUp(){
        transform.GetChild(7).GetComponent<item8controller>().change();
    }public void item9LvUp(){
        transform.GetChild(8).GetComponent<item9controller>().change();
    }
    public void item10LvUp(){
        transform.GetChild(9).GetComponent<item10controller>().change();
    }public void item11LvUp(){
        transform.GetChild(10).GetComponent<item11controller>().change();
    }
    // public void weaponsLvUp(){
    //     itemsLV[0] += 1 ;
    //     weapencontroller.changeWeapon(weapons[itemsLV[0]-1]);
    // }
}
