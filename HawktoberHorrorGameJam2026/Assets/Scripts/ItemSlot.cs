using TMPro;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;


public class ItemSlot : MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private GameObject selector;
    private int itemId;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        SelectToggle(false);
    }

    public int GetItemId()
    {
        return itemId;
    }

    public int SelectToggle(bool selected)
    {
        Debug.Log(" selected: " + selected);
       selector.SetActive(selected);
       return itemId; 
    }
    public void SetImage (Sprite sprite)
    {
        image.sprite = sprite;
    }
    public void SetId(int id)
    {
        itemId = id;
    }
}
