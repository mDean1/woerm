using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//CODE HELP FROM "SETTINGS MENU in Unity" by Brackeys (https://www.youtube.com/watch?v=YOaYQrN1oYQ&t=532s)

public class SettingsMenu : MonoBehaviour
{

    Resolution[] resolutions;
    [SerializeField] TMPro.TMP_Dropdown resolutionDropdown;
    [SerializeField] Toggle toggle;

    void Start (){
        resolutions = Screen.resolutions;

        bool setDefault = false;
        if(PlayerPrefs.GetInt("set default resolution") == 0){
            setDefault = true;
            PlayerPrefs.GetInt("set default resolution",1);
        }
        
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length ; i++){
            string option = resolutions[i].width + " x " + resolutions[i].height + " @ " + resolutions[i].refreshRateRatio + "hz";            
            options.Add(option);
            
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height){
                resolutionDropdown.value = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();
        toggle.isOn = PlayerPrefs.GetInt("fullscreen") == 0;
        resolutionDropdown.value = PlayerPrefs.GetInt("resolution selection");
    }


    public void SetResolution (){
        Screen.SetResolution(resolutions[resolutionDropdown.value].width,resolutions[resolutionDropdown.value].height,true);
        PlayerPrefs.SetInt("resolution selection",resolutionDropdown.value);
    }

    public void SetFullscreen (bool isFullscreen){
        Screen.fullScreen = isFullscreen;
        if(toggle.isOn){
            PlayerPrefs.SetInt("fullscreen",1);
        }else{
            PlayerPrefs.SetInt("fullscreen",0);
        }
    }


}
