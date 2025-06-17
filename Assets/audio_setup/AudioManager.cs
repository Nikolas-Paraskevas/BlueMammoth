using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public GameObject audioEmitterPrefab;

    private List<AudioEmitter> audioEmitters;

    private int audioSourcePoolSize = 10;

    private void Awake()
    {
        audioEmitters = new List<AudioEmitter>(audioSourcePoolSize);

        for (int i = 0; i < audioSourcePoolSize; i++)
        {
            GameObject audioEmitter = Instantiate(audioEmitterPrefab, transform.position, Quaternion.identity);
            audioEmitter.transform.SetParent(transform);
            audioEmitter.name = "AudioEmitter_" + i;
            audioEmitter.SetActive(false); // Deactivate to avoid immediate playback
            AudioEmitter emitter = audioEmitter.GetComponent<AudioEmitter>();
            audioEmitters.Add(emitter);
        }
    }

    public void StopAllAudio()
    {
        foreach (AudioEmitter emitter in audioEmitters)
        {
         emitter.StopAudio();   
        }
    }

    public AudioEmitter GetAudioEmitter()
    {
        if (audioEmitters == null)
        {
            Debug.LogError("Audio source pool is empty. Cannot play audio clip.");
            return null;
        }

        AudioEmitter availableSource = null;
        foreach (AudioEmitter emitter in audioEmitters)
        {
            if (emitter.transform.gameObject.activeSelf == false)
            {
                audioEmitters.Remove(emitter);
                return emitter;
            }
        }
        
        if(availableSource == null)
        {
            Debug.LogWarning("No available audio emitters in the pool. Consider increasing the pool size.");
            return null;
        }
        
        return null;
    }
}
