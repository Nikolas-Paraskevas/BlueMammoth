using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    public AudioClip clip;
    public AudioManager audioManager;   

    private AudioEmitter audioEmitter;
    // Start is called before the first frame update
    void Start()
    {
        audioEmitter = audioManager.GetAudioEmitter();
        audioEmitter.PlayWithCallbacks(clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
