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

    private List<Item> items; // list of references to items in player inventory
    private int numItems; // number of items in player inventory
    private int inspectedId; // slot ID of item currently hovered over/inspected

    [SerializeField]
    private GameObject inventoryInspectorPanel; // where detailed item sprite and desc is listed. activate for item hovered over/inspected

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

    void Awake()
    {
        inspectedId = 0;
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

    void AddItem(Item item)
    {
        items.Add(item);
        items[numItems].slotId = numItems++; // may be unecessary to track slot number within item itself

        // add prefabs to inventory prefab list
    }

    void InspectItem(int itemId)
    {
        // items[itemId] -> get name, desc, sprite; show on inventoryInspectorPanel prefab
        // 
    }

    void LoadInspectedItem(Item item)
    {
        // from inventoryInspectorPanel get children
            // string name
            // string desc
            // Sprite sprite
        // set inventoryInspectorPanel children based on item member values 
    }
    
}
