using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PersistentAudioSource : MonoBehaviour
{
    // Singleton instance variables
    private static PersistentAudioSource instance;
    public static PersistentAudioSource Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        AudioSource myAudio = GetComponent<AudioSource>();
        if(instance != null && instance != this)
        {
            // If there's a persistent audio source with a different audio clip,
            // destroy the current instance of the persistent audio source
            if(myAudio.clip != instance.GetComponent<AudioSource>().clip)
            {
                Destroy(instance.gameObject);
            }
            // Else, destroy the second instance of a persistent audio source
            // that plays the same audio clip
            else
            {
                Destroy(this.gameObject);
                return;
            }
        }

        // Overwrite the current instance of the persistent audio source
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
