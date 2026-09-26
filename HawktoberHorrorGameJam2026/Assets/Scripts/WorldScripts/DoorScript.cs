using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField]
    private Transform connectedRoomTransform;

    [SerializeField]
    private Transform doorOffset;

    [SerializeField]
    private GameObject player;

    //[SerializeField]
    private Camera mainCamera;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //     player = FindObjectOfType<Player>();
        mainCamera = GameObject.FindFirstObjectByType<Camera>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void EnterRoom()
    {
        // //setting camera position to new room
        // mainCamera.transform.position = new Vector3(
        // connectedRoom.transform.position.x,
        // connectedRoom.transform.position.y,
        // transform.position.z);

        // player.transform.position = new Vector3()
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            mainCamera.transform.position = new Vector3(
            connectedRoomTransform.position.x,
            connectedRoomTransform.position.y,
            -10);

            // player.transform.position = new Vector3(connectedRoom.transform.position.x,
            // connectedRoom.transform.position.y,
            // transform.position.z);
            player.transform.position = new Vector3(doorOffset.transform.position.x,
            doorOffset.transform.position.y,
            transform.position.z);

            //Debug.Log("Wassup");
        }
    }
}
