using UnityEngine;

public class RandomSound : MonoBehaviour
{
    
    public AudioSource soundSource;

    public AudioClip[] soundClips;

    void Start()
    {
        if (soundSource == null)
            soundSource = GetComponent<AudioSource>();
        
        soundSource.PlayOneShot(soundClips[Random.Range(0, soundClips.Length)]);
    }


}
