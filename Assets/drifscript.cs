using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class drifscript : MonoBehaviour
{
    public AudioClip clip;
    public AudioManager audioManager;

    private AudioEmitter audioEmitter1;
    private AudioEmitter audioEmitter2;

    private bool useFirstEmitter = true;

    void Start()
    {
        audioEmitter1 = audioManager.GetAudioEmitter();
        audioEmitter2 = audioManager.GetAudioEmitter();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (useFirstEmitter)
                audioEmitter1.PlayWithCallbacks(clip);
            else
                audioEmitter2.PlayWithCallbacks(clip);

            useFirstEmitter = !useFirstEmitter;
        }
    }
}