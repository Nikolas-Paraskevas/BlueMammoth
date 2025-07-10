using UnityEngine;
using TMPro;

public class WaveTrigger : MonoBehaviour
{

    public TextMeshPro waveText;          // Sleep hier je tekstcomponent in

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        EnemySpawner spawner = FindObjectOfType<EnemySpawner>();
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;

            // Start de waves
            if (spawner != null)

            // Toon Wave 1 tekst
            if (waveText != null)
            {
                waveText.text = "Wave 1";
                waveText.gameObject.SetActive(true);
                Invoke(nameof(HideWaveText), 3f);
            }
        }
    }

    void HideWaveText()
    {
        if (waveText != null)
            waveText.gameObject.SetActive(false);
    }
}
