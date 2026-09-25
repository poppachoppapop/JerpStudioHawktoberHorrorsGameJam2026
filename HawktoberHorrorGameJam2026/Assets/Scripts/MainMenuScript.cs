using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private Canvas mainMenuCanvas;
    [SerializeField] private Canvas creditsCanvas;

    
    [SerializeField] private Button playButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button quitButton;

    [SerializeField] private Button quitCreditsButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        creditsCanvas.gameObject.SetActive(false);

        playButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("MainLevel");
        });

        creditsButton.onClick.AddListener(() =>
        {
            mainMenuCanvas.gameObject.SetActive(false);
            creditsCanvas.gameObject.SetActive(true);
        });

        quitButton.onClick.AddListener(() =>
        {
            if(!Application.isEditor)
            {
                Application.Quit();
            }
            else
            {
                Debug.Log("Quitting Game... SIKE! Just a test. :3");
            }
        });

        quitCreditsButton.onClick.AddListener(() =>
        {
            mainMenuCanvas.gameObject.SetActive(true);
            creditsCanvas.gameObject.SetActive(false);
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
