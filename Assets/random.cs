using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random : MonoBehaviour
{
    public AudioClip clip;
    public AudioClip background;
    public AudioManager audioManager;

    private AudioEmitter audioEmitter1;
    private AudioEmitter audioEmitter2;
    void Start()
    {
        audioEmitter1 = audioManager.GetAudioEmitter();
        audioEmitter2 = audioManager.GetAudioEmitter();
        audioEmitter1.PlayWithCallbacks(background, true);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            Fire();

        }

    }

    private void Fire()
    {
        audioEmitter2.PlayWithCallbacks(clip);
    }

}
