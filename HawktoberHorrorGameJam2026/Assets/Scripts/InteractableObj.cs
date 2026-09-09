using UnityEngine;

public class InteractableObj : MonoBehaviour
{
    [Header("Interacted Text")]
    [SerializeField] public string[] textInput;
 
    //Image based interactable object
    
    [Header("Piicture Stuff")]
    [SerializeField] public bool imageBased = false;
    [SerializeField] private GameObject picture;
    [SerializeField] private Canvas canvasRef;

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
