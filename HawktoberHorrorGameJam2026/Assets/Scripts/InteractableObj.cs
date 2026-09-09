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
    [SerializeField] private Canvas canvasRef;

    [Header("Item Stuff")]
    [SerializeField] public int itemBased = 0;

    void Start()
    {
        if (canvasRef == null)
            canvasRef = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
    }

    public void ViewPicture()
    {
        picture.transform.SetParent(canvasRef.transform);
    }

    public void ClosePicture()
    {
        picture.transform.SetParent(transform);
    }
}
