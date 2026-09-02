using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class PlayerInteraction : MonoBehaviour
{

    [Header("Input System")]
    [SerializeField]
    private InputActionReference interact;

    private GameObject interactableObject;

    private string[] objectText;


    [SerializeField]
    private Dialogue dialogueBox;
    private bool dialogueIsActive;

    void Start()
    {
        //dialogueBox = transform.GetChild(0).transform.GetChild(0).GetComponent<Dialogue>();
       CloseDialogue(); 
    } 

    void Update()
    {
        LoadInteractAction();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Interactable")
        {
            objectText = col.GetComponent<InteractableObj>().textInput;
            interactableObject = col.gameObject;
        }
    }

        void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Interactable")
        {
            interactableObject = null;
        }
    }

    void LoadInteractAction()
    {
        //determine if this is just:
        // TEXT BOX INTERACTION
        // ITEM INTERACTION
        // EVENT INTERACTION

        if (interactableObject != null && interact.action.WasPressedThisFrame())
        {
            Debug.Log(objectText);
            //Input textbox stuff here and pass objectText into it
            if (dialogueIsActive)
            {
                if (!dialogueBox.NextLine()) CloseDialogue(); 
            }
            else
            {
                ActivateDialogue();
            }
        }
    }

    void ActivateDialogue()
    {
            dialogueBox.gameObject.SetActive(true);
            dialogueBox.StartDialogue(objectText);
            dialogueIsActive = true;
    }

    void CloseDialogue()
    {
            dialogueBox.resetDialogue();
            dialogueBox.gameObject.SetActive(false);
            dialogueIsActive = false;
    }
}
