using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text talkText;
    public GameObject scanObject;
    public GameObject menu;

    void Update() {
        
        if(Input.GetButtonDown("Cancel")){
            if(menu.activeSelf)
                menu.SetActive(false);
            else
            menu.SetActive(true);
        }
    }

    public void Action(GameObject scanObj){
        scanObject = scanObj;
        talkText.text = "이것은 " + scanObject.name;
    }
}
