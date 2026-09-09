using System.Collections;
using UnityEngine;

public class FacelessGuy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool up, down, left, right;

    public float speed = 2f;

    private bool triggered = false;

    public float deathTimer = 2f;

    public float stepTimer = 0;
    public float stepTimerMax = 0.2f;
    public AudioSource stepSource;


    // Update is called once per frame
    
    void Update()
    {
        if (Vector3.Distance(Camera.main.transform.position, transform.position) < 14)
        {
            if (!triggered)
            {
                Destroy(gameObject, deathTimer);
                triggered = true;
                if (right)
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
            else
                WalkOffScreen();

        }
        Debug.Log(Vector3.Distance(Camera.main.transform.position, transform.position));
    }

    void WalkOffScreen()
    {
        StepTrigger();
        if (right)
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime) , transform.position.y);
        if (left)
            transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime) , transform.position.y);
        if (up)
            transform.position = new Vector2(transform.position.x, transform.position.y + (speed * Time.deltaTime));
        if (down)
            transform.position = new Vector2(transform.position.x, transform.position.y - (speed * Time.deltaTime));
    }

    void StepTrigger()
    {
        stepTimer -= Time.deltaTime;
        if (stepTimer <= 0)
        {
            stepSource.pitch = UnityEngine.Random.Range(0.7f, 1.1f);
            stepSource.Play();
            stepTimer = stepTimerMax;
        }
        Debug.Log(stepTimer);
    }
}
