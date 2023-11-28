using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// CODE HELP FROM "PAUSE MENU in Unity" by Brackeys (https://www.youtube.com/watch?v=JivuXdrIHK0)

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public static bool isSettingsOpen = false;
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            
            if (isSettingsOpen){
                Return();
            }
            else if (isPaused){
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Return(){
        pauseMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
        isSettingsOpen = false;
    }

    public void Settings(){
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
        isSettingsOpen = true;
    }

    public void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start Menu");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
