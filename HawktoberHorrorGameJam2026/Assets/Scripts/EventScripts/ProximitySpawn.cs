using Unity.VisualScripting;
using UnityEngine;

public class ProximitySpawn : MonoBehaviour
{

    public GameObject spawnableObject;
    
    GameObject playerRef;

    public float distanceTrigger = 1f;

    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
         if (Vector3.Distance(playerRef.transform.position, transform.position) < distanceTrigger)
        {
            Instantiate(spawnableObject, transform.position, transform.rotation);
            Destroy(gameObject);
            Debug.Log(Vector3.Distance(playerRef.transform.position, transform.position));
        }
    }
}
