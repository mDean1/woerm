using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class proximityDetection : MonoBehaviour
{
    bool playerClose = false;
    public GameObject template;
    public GameObject canvas;

   
    // Update is called once per frame
    void Update()
    {
        if(playerClose && Input.GetKeyDown(KeyCode.F)){
            canvas.SetActive(true);
            soulMovement.dialogue = true;
            NewDialogue("...");
            NewDialogue("You seem...unsettled. Bad choice last reincarnation? Or perhaps that was your first time dying?");
            NewDialogue("Don't be scared... To some this realm is called \"Heaven\", \"Hell\", \"Nirvana\", \"Valhalla\", \"Purgatory\", \"Paradise\", it goes by many titles.");
            NewDialogue("Regardless of the name you give it, it serves the same purpose. A waiting room for souls between reincarnations...");
            NewDialogue("...");
            NewDialogue("I can sense... a heavy weight in your soul.");
            NewDialogue("We don't forget. That's the problem, you see? You will always carry the feelings of your past lives.");
            NewDialogue("You'll experience all this... Every time you're here. Only way to forget is to reincarnate, to seek out a new life.");
            NewDialogue("However... you have the power to choose your next life, and the life after, for the rest of infinity.");
            NewDialogue("Some are hungered for power, seeking out reincarnations of powerful rulers, however most lives are messy...dirty...violent...");
            NewDialogue("...");
            NewDialogue("Be wise in your choices. You have infinite tries... but we don't forget.");
            canvas.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player")){
            playerClose = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player")){
            playerClose = false;
        }
    }

    void NewDialogue(string text){
        GameObject template_clone = Instantiate(template, template.transform);
        template_clone.transform.parent = canvas.transform;
        template_clone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
    }
    
}
