
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class popandpoof : MonoBehaviour
{


    Vector3 originalPos;
    public int times = 10;

    public float rangeMin = 1, rangeMax = 1;
    void Start()
    {
        originalPos = transform.position;
        rangeMin *= -1;
        StartCoroutine(Teleport());
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(0.05f);

        Vector3 target = new Vector3(originalPos.x + Random.Range(rangeMin, rangeMax), originalPos.y + Random.Range(rangeMin, rangeMax), 0);

        transform.position = target;
        times--;
        if (times > 0)
            yield return Teleport();
        else
            Destroy(gameObject);

    }



}
