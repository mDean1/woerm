using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


/*
    CODE FROM BMo's "5 Minute DIALOGUE SYSTEM in UNITY Tutorial" (https://www.youtube.com/watch?v=8oTYabhj248)
*/

public class Dialogue : MonoBehaviour
{

    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    [SerializeField] public SceneFader sceneFader;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

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
            int nextScene = (SceneManager.GetActiveScene().buildIndex + 1);
            sceneFader.FadeOut(nextScene);
            StartCoroutine(waitTime());
        }
    }

    IEnumerator waitTime()
    {
			while (true)
            {
                yield return new WaitForSeconds(2.9f);

				gameObject.SetActive(false);

			}

            yield return null;
		}
}
