using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class PersistentAudioSource : MonoBehaviour
{
    private AudioSource myAudio = null;
    // Singleton instance variables
    private static PersistentAudioSource instance;
    public static PersistentAudioSource Instance
    {
        get { return instance; }
    }

    [SerializeField] private bool willResetGameobject = false;

    void Awake()
    {
        myAudio = GetComponent<AudioSource>();
        if(instance != null && instance != this)
        {
            // If:
            // a) there's a persistent audio source with a different audio clip or
            // b) you wanna reset the singleton gameobject,
            // destroy the current instance of the persistent audio source
            if(myAudio.clip != instance.GetComponent<AudioSource>().clip || willResetGameobject)
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

    void OnEnable()
    {
        CutsceneManager.OnAudioFadeOut += SignalFadeOut;
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(this.gameObject);
        }
    }

    // Duration is in seconds
    public IEnumerator FadeOut(float duration)
    {
        float startVolume = myAudio.volume;
        while(myAudio.volume > 0f)
        {
            myAudio.volume -= startVolume * Time.deltaTime / duration;
            yield return null;
        }
        myAudio.Stop();
    }

    public void SignalFadeOut(float duration)
    {
        StartCoroutine(FadeOut(duration));
    }
}
