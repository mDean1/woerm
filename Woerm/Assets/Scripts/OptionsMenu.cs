using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// CODE HELP FROM "PAUSE MENU in Unity" by Brackeys (https://www.youtube.com/watch?v=JivuXdrIHK0)

public class OptionsMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject settingsMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            
            if (isPaused){
                Resume();
            }

            else {
                Pause();
            }
        }
    }

    public void Resume(){
        settingsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }


    public void Pause(){
        settingsMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
}
