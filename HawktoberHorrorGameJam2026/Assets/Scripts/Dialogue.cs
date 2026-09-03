//might be super inefficient because baby's first dialogue box xd
using UnityEngine;
using System.Collections;
using TMPro;
using System;
using UnityEngine.UI;


public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // reference to TMP component
    public float textSpeed;

    public string[] textLines;
    private int textIterId;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resetDialogue();
    }

    IEnumerator TypeLine()
    {
        foreach (char c in textLines[textIterId].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void LoadLine()
    {
        textComponent.text = string.Empty;
        StartCoroutine(TypeLine());
    }

    public void StartDialogue(string[] textInput) //! use this to trigger text box after the object is set active
    {
        textLines = textInput;
        LoadLine();
    }

    public bool NextLine()
    {
        int currId = textIterId;
        int nextId = currId + 1;

        string currLine = textLines[currId];

        if (textComponent.text != currLine)
        {
            StopAllCoroutines();
            textComponent.text = currLine;
        }
        else if (nextId >= textLines.Length || textLines[nextId] == string.Empty)
        {
            Debug.Log("End of textLines array (Cannot display next line)\n");
            return false;
        }
        else
        {
            textIterId++;
            LoadLine();
        }
        return true;
    }

    public void resetDialogue()
    {
        textComponent.text = string.Empty;
        textLines = Array.Empty<string>();
        textIterId = 0;
    }
}
