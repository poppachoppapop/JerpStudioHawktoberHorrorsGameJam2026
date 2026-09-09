//TODO Change Inventory UI to list instead of grid
//TODO Inventory navigation system
//TODO Test picking up items
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<Item> itemsList; // list of references to items possible to obtain

    [SerializeField]
    private List<ItemSlot> itemSlots; //list of item slots in inventory
    private int nextEmptySlot = 0;

    private int prevInspectedSlot = -1;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Serializable]
    private struct InventoryInspectorPanel
    {
        public TextMeshProUGUI name;
        public TextMeshProUGUI description;
        public Image image;
    }
    
    [SerializeField]
    private InventoryInspectorPanel inventoryInspectorPanel; // where detailed item sprite and desc is listed. activate for item hovered over/inspected

    void Start()
    {
        
    }

    void Awake()
    {
        InspectSlotItem(0);
    }




    public void AddItem(int itemId)
    {
        //items.Add(item.itemID);
        //items[numItems].slotId = numItems++; // may be unecessary to track slot number within item itself

        // add prefabs to inventory prefab list
        Item item = itemsList[itemId]; // get item scriptable object 
        ItemSlot itemSlot = itemSlots[nextEmptySlot++]; //obtain reference to next empty slot of item prefab list
        
        itemSlot.SetId(itemId);
        itemSlot.SetImage(item.itemSprite);
    }

    void InspectSlotItem(int slotId)
    {
        if (prevInspectedSlot == slotId) return;
        
        ItemSlot slot = itemSlots[slotId];
        int itemId = slot.SelectToggle(true); // turns on selector and gets itemID
        LoadInspectedItem(itemsList[itemId]);
        prevInspectedSlot = slotId;
    }

    void LoadInspectedItem(Item item)
    {
        inventoryInspectorPanel.name.text = item.itemName;
        inventoryInspectorPanel.description.text = item.itemDesc;
        inventoryInspectorPanel.image.sprite = item.itemSprite;
    }
}
