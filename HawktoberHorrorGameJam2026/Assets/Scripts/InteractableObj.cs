using UnityEngine;

public class InteractableObj : MonoBehaviour
{
    [Header("Interacted Text")]
    [SerializeField] public string[] textInput;
 
    //Image based interactable object
    
    [Header("Piicture Stuff")]
    [SerializeField] public bool imageBased = false;
    [SerializeField] private GameObject picture;

    public void ViewPicture()
    {
        picture.SetActive(true);
    }

    public void ClosePicture()
    {
        picture.SetActive(false);
    }

}
