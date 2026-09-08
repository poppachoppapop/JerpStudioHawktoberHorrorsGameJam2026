using JetBrains.Annotations;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class InteractableObj : MonoBehaviour
{
    [Header("Interacted Text")]
    [SerializeField] public string[] textInput;
 
    //Image based interactable object
    
    [Header("Picture Stuff")]
    [SerializeField] public bool imageBased = false;
    [SerializeField] private GameObject picture;

    [Header("Item Stuff")]
    [SerializeField] public int itemBased = 0;


    public void ViewPicture()
    {
        picture.SetActive(true);
    }

    public void ClosePicture()
    {
        picture.SetActive(false);
    }
}
