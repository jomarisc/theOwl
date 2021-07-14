using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersistentSfx : MonoBehaviour
{

    public AudioSource mySfx;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        mySfx = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // mySfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!mySfx.isPlaying)
        {
            Destroy(this.gameObject);
        }
    }

    // void OnEnable()
    // {
    //     mySfx.Play();
    //     StartCoroutine(SfxFinish());
    // }
}
