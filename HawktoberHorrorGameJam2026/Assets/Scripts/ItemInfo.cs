using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject 
{    
    private string slotId;

    [SerializeField]
    private string itemName;

    [SerializeField]
    private string itemDesc;
    
    [SerializeField]
    private Sprite itemSprite;
}

