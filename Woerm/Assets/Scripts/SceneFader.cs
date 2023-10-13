using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{

    [SerializeField] Image fadeImage;
    [SerializeField] Image glowImage;
    [SerializeField] Color fadeInColor = Color.black;
    [SerializeField] Color fadeOutColor = Color.black;
    [SerializeField] float fadeTime = 1;
    [SerializeField] float slideTime = 6;
    public bool fadingOut = false;


    void Start()
    {
        FadeIn();
    }

    public void FadeIn(){
        StartCoroutine(FadeInRoutine());
        IEnumerator FadeInRoutine(){
            float timer = 0;
            while(timer < fadeTime){
                fadeImage.color = new Color(fadeInColor.r,fadeInColor.g,fadeInColor.b,1f-(timer/fadeTime));
                timer+=Time.deltaTime;
                yield return null;
            }

            fadeImage.color = Color.clear;
            yield return null;
        } 
    }

     public void FadeOut(string sceneName){
        if(fadingOut){
            return;
        }
        fadingOut = true;
        StartCoroutine(FadeOutRoutine());
        IEnumerator FadeOutRoutine(){
            float timer = 0f;
            while(timer < fadeTime){
                fadeImage.color = new Color(fadeOutColor.r,fadeOutColor.g,fadeOutColor.b, (timer/fadeTime));
                timer+=Time.deltaTime;
                yield return null;
            }
            fadeImage.color = fadeOutColor;
            yield return null;
            SceneManager.LoadScene(sceneName);
        }
    }

    

    public void swirlOut(){
        StartCoroutine(SwirlOutRoutine());
        IEnumerator SwirlOutRoutine(){
            float timer = 0;
            while(timer < slideTime){
                timer+=Time.deltaTime;
                
                glowImage.transform.localScale += new Vector3(1, 1, 1) * (Time.deltaTime) * 11;
                glowImage.transform.Rotate(new Vector3(0,0,-45) * (Time.deltaTime * 2f), Space.Self);

                yield return null;
            }
            yield return null;
            SceneManager.LoadScene("Forest");
        }
    }
    
}