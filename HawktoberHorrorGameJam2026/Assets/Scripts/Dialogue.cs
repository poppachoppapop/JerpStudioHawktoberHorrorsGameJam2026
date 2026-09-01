//might be super inefficient because baby's first dialogue box xd

// #define TEST_MODE //* (enables keyboard input for debug use only, uncomment to enable)

using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using TMPro;


public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // reference to TMP component
    public float textSpeed;

    public string[] textLines;
    private int textIterId;
    private int textProgressId;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.textComponent.text = string.Empty;
        this.StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        #if TEST_MODE  //* uncomment TEST_MODE to enable 
            if(Keyboard.current.rightArrowKey.wasPressedThisFrame)
            {
                string line = this.textLines[this.textIterId];
                if (this.textComponent.text == line)
                {
                    this.NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    this.textComponent.text = line;
                }
            }

            if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
            {
                StopAllCoroutines();
                this.PrevLine();    
            }
        #endif
    }
    
    void StartDialogue()
    {
        this.textIterId = 0;
        StartCoroutine(this.TypeLine());
    }

    void NextLine()
    {
       ++this.textIterId; 
       if (this.textIterId >= this.textLines.Length)
        {
            this.textIterId--;
            Debug.Log("End of textLines array (Cannot display next line)\n");
        }
        else if (this.textIterId <= this.textProgressId) // already-seen text
        { 
            this.textComponent.text = this.textLines[this.textIterId];           
        } 
        else //unread text
        {
            this.textComponent.text = string.Empty;
            StartCoroutine(this.TypeLine());
            ++this.textProgressId;
        }

   }
   
    void PrevLine()
    {
       if (this.textIterId == 0)
        {
            Debug.Log("Start of textLines array (Cannot display previous line)\n");
            return;
        }
        this.textComponent.text = this.textLines[--this.textIterId];
   }

    IEnumerator TypeLine()
    {
        foreach (char c in this.textLines[this.textIterId].ToCharArray())
        {
            this.textComponent.text += c;
            yield return new WaitForSeconds(this.textSpeed);
        }
    }
}
