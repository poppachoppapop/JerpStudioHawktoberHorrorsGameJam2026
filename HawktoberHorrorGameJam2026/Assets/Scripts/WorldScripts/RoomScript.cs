using UnityEngine;

public class RoomScript : MonoBehaviour
{
    [SerializeField]
    private bool IsLargeRoom = false;

    EdgeCollider2D roomBounds;

    BoxCollider2D roomLeavingBounds;

    Camera mainCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = GameObject.FindFirstObjectByType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetCameraToCurrentRoom(Collider2D roomBounds)
    {
        if (mainCamera == null)
        {
            Debug.Log("No Available Camera to work with");
            return;
        }

        

    }
}
