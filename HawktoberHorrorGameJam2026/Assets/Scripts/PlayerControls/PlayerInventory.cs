using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    
    [SerializeField]
    private InputActionReference inventoryInputRef; // set to tab in input manager

    private bool inventoryIsActive;

    [SerializeField]
    private Canvas inventoryCanvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       ToggleInventory(false); 
    }

    // Update is called once per frame
    void Update()
    {
       LoadInventoryAction();
    }

    void LoadInventoryAction()
    {
        if (!inventoryInputRef) return;
        if (inventoryInputRef.action.WasPressedThisFrame())
        {
            if (!inventoryIsActive)
            {
                ToggleInventory(true);
                //Debug.Log("inventory on");
            }
            else 
            {
                ToggleInventory(false);
                //Debug.Log("inventory off");
            }
        }

    }

    void ToggleInventory(bool active)
    {
        if(!inventoryCanvas) return;
        Time.timeScale = active ? 0 : 1; // pause game if menu open
        inventoryCanvas.gameObject.SetActive(active);
        inventoryIsActive = active;
    }
}
