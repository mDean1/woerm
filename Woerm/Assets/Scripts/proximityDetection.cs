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
            NewDialogue("Don't be scared... To some this realm is called \"Heaven\", \"Hell\", \"Nirvana\", \"Valhalla\", \"Purgatory\", \"Paradise\". It goes by many titles.");
            NewDialogue("Regardless of the name you give it, it serves the same purpose. A waiting room for souls between reincarnations.");
            NewDialogue("...");
            NewDialogue("I can sense... a heavy weight in your soul.");
            NewDialogue("We don't forget. That's the problem, you see? You will always carry the memories and feelings of your past lives.");
            NewDialogue("You'll experience this every time you're here. Only way to momentarily forget is to reincarnate, to seek out a new life.");
            NewDialogue("However... you get to decide who or what to be in your next life, and the life after, for the rest of infinity.");
            NewDialogue("Some here have gone crazed with their deside for power, however most lives are messy...dirty...violent...");            
            NewDialogue("Sometimes the best memories come from the simpliest lives. Most of us here can attest to that.");
            NewDialogue("...");
            NewDialogue("Be wise in your choices. You have infinite tries... but you won't ever forget your past.");
            NewDialogue("Anyway... whenever you decide you're ready to be reborn, close your eyes, think about who, what, and where you want to be, and then press [R].");
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
            canvas.SetActive(false);
            playerClose = false;
        }
    }

    void NewDialogue(string text){
        GameObject template_clone = Instantiate(template, template.transform);
        template_clone.transform.parent = canvas.transform;
        template_clone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
    }
    
}
