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
    public InputActionReference interactInputRef, moveInputRef;



    private GameObject interactableObject;

    private string[] objectText;


    [SerializeField]
    private Dialogue dialogueBox;
    private bool dialogueIsActive;



    void Start()
    {
        //dialogueBox = transform.GetChild(0).transform.GetChild(0).GetComponent<Dialogue>();
        ToggleDialogue(false);

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

        // Picture interaction
        //Make picture visible

        //text interaction
        if (interactableObject != null && interactInputRef.action.WasPressedThisFrame())
        {
            InteractableObj obj = interactableObject.GetComponent<InteractableObj>();

            Debug.Log(objectText);
            //Input textbox stuff here and pass objectText into it
            if (!dialogueIsActive)
            {
                ToggleDialogue(true);

                if (obj != null && obj.imageBased)
                    obj.ViewPicture();
            }

            else if (!dialogueBox.NextLine())
            {
                if (obj != null && obj.imageBased)
                    obj.ClosePicture();
                    
                ToggleDialogue(false);
            }


        }
    }
    void ToggleDialogue(bool active)
    {
        if (!dialogueBox) return; //terminate early if null dialogueBox

        if (active)
        {
            dialogueBox.gameObject.SetActive(true);
            dialogueBox.StartDialogue(objectText);
            dialogueIsActive = true;
            moveInputRef.action.Disable();
        }
        else
        {
            dialogueBox.resetDialogue();
            dialogueBox.gameObject.SetActive(false); //?error "Object reference not set to an instance of an object" here. Is this because the reference is lost when inactive?.
            dialogueIsActive = false;
            moveInputRef.action.Enable();
        }
    }

}
