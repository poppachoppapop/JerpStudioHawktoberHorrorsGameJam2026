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
    public InputActionReference interact, moveRef;

    [SerializeField]
    private InputActionReference inventory;

    private GameObject interactableObject;

    private string[] objectText;


    [SerializeField]
    private Dialogue dialogueBox;
    private bool dialogueIsActive;
    private bool inventoryIsActive;

    [SerializeField]
    private Canvas inventoryCanvas;

    void Start()
    {
        //dialogueBox = transform.GetChild(0).transform.GetChild(0).GetComponent<Dialogue>();
        ToggleDialogue(false);
        ToggleInventory(false);
    }

    void Update()
    {
        LoadInteractAction();
        LoadInventoryAction();
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
        if (interactableObject != null && interact.action.WasPressedThisFrame())
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

    void LoadInventoryAction()
    {
        if (inventory.action.WasPressedThisFrame())
        {
            if (!inventoryIsActive)
            {
                ToggleInventory(true);
                //Debug.Log("this is on");
            }
            else 
            {
                ToggleInventory(false);
                //Debug.Log("this is off");
            }
        }

    }

    void ToggleInventory(bool active)
    {

        if(!inventoryCanvas) return;


        if (active)
        {
            inventoryCanvas.gameObject.SetActive(true);
            inventoryIsActive = true;
        }
        else
        {
            inventoryCanvas.gameObject.SetActive(false);
            inventoryIsActive = false;
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
            moveRef.action.Disable();
        }
        else
        {
            dialogueBox.resetDialogue();
            dialogueBox.gameObject.SetActive(false); //?error "Object reference not set to an instance of an object" here. Is this because the reference is lost when inactive?.
            dialogueIsActive = false;
            moveRef.action.Enable();
        }
    }

}
