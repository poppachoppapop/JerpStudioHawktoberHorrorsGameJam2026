using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject 
{
    [SerializeField]
    public int itemID;

    [SerializeField]
    public string itemName;

    [SerializeField]
    public string itemDesc;
    
    [SerializeField]
    public Sprite itemSprite;
}

