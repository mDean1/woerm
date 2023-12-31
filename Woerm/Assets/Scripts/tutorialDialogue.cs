using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


/*
    CODE FROM BMo's "5 Minute DIALOGUE SYSTEM in UNITY Tutorial" (https://www.youtube.com/watch?v=8oTYabhj248)
*/

public class tutorialDialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public GameObject tutorialCanvas;
    public string[] lines;
    public float textSpeed;
    private int index;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void Start()
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
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            tutorialCanvas.SetActive(false);
        }
    }
}
