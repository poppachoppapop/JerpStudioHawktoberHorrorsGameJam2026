//might be super inefficient because baby's first dialogue box xd

using UnityEngine;
using UnityEngine.InputSystem;
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
        this.resetDialogue();
    }

    public void StartDialogue(string[] textInput) //! use this to trigger text box after the object is set active
    {
        this.textLines = textInput;
        this.LoadLine();
    }

    public bool NextLine()
    {
        int currId = this.textIterId;
        int nextId = currId + 1;

       string currLine = this.textLines[currId];

        if (this.textComponent.text != currLine)
        {
            StopAllCoroutines();
            this.textComponent.text = currLine;
        }
        else 
        {
            if (nextId >= this.textLines.Length || this.textLines[nextId] == string.Empty)
            {
                Debug.Log("End of textLines array (Cannot display next line)\n");
                return false;
            }
 
            this.textIterId++;
            this.LoadLine();
        };

        return true;
    }

    public void resetDialogue()
    {
        this.textComponent.text = string.Empty;
        this.textLines = Array.Empty<string>();
        this.textIterId = 0;
    }

    IEnumerator TypeLine()
    {
        foreach (char c in this.textLines[this.textIterId].ToCharArray())
        {
            this.textComponent.text += c;
            yield return new WaitForSeconds(this.textSpeed);
        }
    }
    void LoadLine()
    {
        this.textComponent.text = string.Empty;
        StartCoroutine(TypeLine());
    }


}
