using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stereoSound : MonoBehaviour
{
    public float panSpeed = 0.25f; // Speed of panning
    public float panAmplitude = 1.0f; // Amplitude of the panning (how far it pans)
    private AudioSource audioSource;

    void Start()
    {
        // Find the AudioSource component on the GameObject named "menuidle"
        audioSource = GameObject.Find("menuidle").GetComponent<AudioSource>();
    }

    void Update()
    {
        // Calculate the pan value using a sinusoidal wave
        float panValue = Mathf.Sin(Time.time * panSpeed) * panAmplitude;
        
        // Set the pan value to the AudioSource
        audioSource.panStereo = panValue;

        // If you want to loop the audio, check if it's not playing and then play it
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
