using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceController : MonoBehaviour
{
    
    private AudioSource audioSource;
    public static AudioSource AudioSourceInstance {
        get; private set;
    }

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        AudioSourceInstance = audioSource; 

    }

  
}
