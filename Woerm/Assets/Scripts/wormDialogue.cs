using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


/*
    CODE FROM BMo's "5 Minute DIALOGUE SYSTEM in UNITY Tutorial" (https://www.youtube.com/watch?v=8oTYabhj248)
*/

public class wormDialogue : MonoBehaviour
{

    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    [SerializeField] public SceneFader sceneFader;
    private int index;

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        yield return new WaitForSeconds(2);
        NextLine();
    }

    void NextLine()
    {
        StopAllCoroutines();
        textComponent.text = string.Empty;
        int nextScene = (SceneManager.GetActiveScene().buildIndex + 1);
        sceneFader.FadeOut(nextScene);
        
    }
}
