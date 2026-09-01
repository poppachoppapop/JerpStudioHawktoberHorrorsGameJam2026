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

    private string objectText;

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
            objectText = "There's nothing here";
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
        }

    }
}
