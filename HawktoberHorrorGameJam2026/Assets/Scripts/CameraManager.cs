using UnityEngine;

public class CameraManager : MonoBehaviour
{
    
    // Simple script that moves the camera 7.5 units x axis or 5 units y axis

    public Transform pTrans;

    [SerializeField] float screenHeight = 10, screenWidth = 13.33f;

    private Vector3 targetPos;
    void Start()
    {
        targetPos = transform.position;
    }

    void Update()
    {
        int roomX = Mathf.FloorToInt((pTrans.position.x + (screenWidth / 2f)) / screenWidth);
        int roomY = Mathf.FloorToInt((pTrans.position.y + (screenHeight / 2f)) / screenHeight);

        float targetX = (roomX * screenWidth);
        float targetY = (roomY * screenHeight);

        targetPos = new Vector3(targetX, targetY, transform.position.z);

        transform.position = targetPos;
    }
}
