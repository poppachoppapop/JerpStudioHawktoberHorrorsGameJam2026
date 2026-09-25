using UnityEngine;
using UnityEngine.UI;


public class FadeCamera : MonoBehaviour
{

    [SerializeField] private Image fadeImage;
    private float fadeSpeed = 0.35f;

    private float targetAlpha = 0.0f;
    private float currentAlpha = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (fadeImage == null)
        {
            Debug.Log("You fool it cant fade in.");
            return;
        }

        currentAlpha = 1.0f;
        SetImageAlpha(currentAlpha);
        FadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        // Smoothly interpolate towards the target alpha using Mathf.MoveTowards
        if (!Mathf.Approximately(currentAlpha, targetAlpha))
        {
            currentAlpha = Mathf.MoveTowards(currentAlpha, targetAlpha, fadeSpeed * Time.deltaTime);
            SetImageAlpha(currentAlpha);
        }
    }

    void FadeIn()
    {
        targetAlpha = 0.0f;
    }

    void FadeOut()
    {
        targetAlpha = 1.0f;
    }

    private void SetImageAlpha(float alpha)
    {
        Color color = fadeImage.color;
        color.a = alpha;
        fadeImage.color = color;
    }
}
