using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField]
    private Transform connectedRoomTransform;

    [SerializeField]
    private Transform doorOffset;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private bool IsLocked;

    //[SerializeField]
    private Camera mainCamera;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = GameObject.FindFirstObjectByType<Camera>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetCurrentRoom()
    {
            mainCamera.transform.position = new Vector3(
            connectedRoomTransform.position.x,
            connectedRoomTransform.position.y,
            -10);

            // player.transform.position = new Vector3(connectedRoom.transform.position.x,
            // connectedRoom.transform.position.y,
            // transform.position.z);
            player.transform.position = new Vector3(
            doorOffset.transform.position.x,
            doorOffset.transform.position.y,
            transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && !IsLocked)
        {
            SetCurrentRoom();
        }
        else
        {
            Debug.Log("Not gonna work big dawg");
        }
    }
}
