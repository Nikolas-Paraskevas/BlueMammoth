using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEmitter : MonoBehaviour
{

    private AudioSource source;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void StopAudio()
    {
        if (source != null && source.isPlaying)
        {
            source.Stop();
        }
    }
    
    public void PlayWithCallbacks(AudioClip clip, bool loop = false, Action onComplete = null, Action onFirstLoopComplete = null, Action onEveryLoop = null)
    {
        this.gameObject.SetActive(true);
        source.clip = clip;
        source.loop = loop;
        source.Play();

        if (loop)
        {
            StartCoroutine(WatchLoops(source, onFirstLoopComplete, onEveryLoop));
        }
        else
        {
            StartCoroutine(WaitForEnd(source, onComplete));
        }
    }

    private IEnumerator WaitForEnd(AudioSource source, Action onComplete)
    {
        yield return new WaitWhile(() => source.isPlaying);
        this.gameObject.SetActive(false);
        onComplete?.Invoke();
    }

    private IEnumerator WatchLoops(AudioSource source, Action onFirstLoopComplete, Action onEveryLoop)
    {
        // Wait a frame or two because it can break...
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();

        int lastSample = source.timeSamples;
        bool firstLoopDone = false;

        while (source != null && source.isPlaying && source.loop)
        {
            int currentSample = source.timeSamples;

            // Detect wraparound
            if (currentSample < lastSample)
            {
                if (!firstLoopDone && onFirstLoopComplete != null)
                {
                    onFirstLoopComplete.Invoke();
                    firstLoopDone = true;
                }

                onEveryLoop?.Invoke();
            }

            lastSample = currentSample;
            yield return null;
        }
    }
}