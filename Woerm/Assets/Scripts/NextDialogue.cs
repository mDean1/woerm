using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDialogue : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        int index = 2;
        if(Input.GetMouseButtonDown(0) && transform.childCount > 1){
            if (soulMovement.dialogue){
                transform.GetChild(index).gameObject.SetActive(true);
                index++;
                if (transform.childCount == index){
                    index = 2;
                    soulMovement.dialogue = false;
                }
            }
            else {
                gameObject.SetActive(false);
            }
        }
    }
}
