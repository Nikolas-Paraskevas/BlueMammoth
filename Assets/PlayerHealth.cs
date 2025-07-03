using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    public Slider healthBarSlider;
    public Transform respawnPoint; // Assign in Inspector or dynamically

    void Start()
    {
        currentHealth = maxHealth;

        if (healthBarSlider != null)
        {
            healthBarSlider.maxValue = maxHealth;
            healthBarSlider.value = currentHealth;
        }

        Debug.Log("PlayerHealth: Initialized with " + currentHealth + " health.");
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log("PlayerHealth: Took " + amount + " damage. Health now: " + currentHealth);

        if (healthBarSlider != null)
        {
            healthBarSlider.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("PlayerHealth: Player died.");
        Respawn();
    }

    void Respawn()
    {
        Debug.Log("PlayerHealth: Respawning...");
        currentHealth = maxHealth;

        if (healthBarSlider != null)
        {
            healthBarSlider.value = currentHealth;
        }

        // Move player to the respawn point
        if (respawnPoint != null)
        {
            transform.position = respawnPoint.position;
        }
        else
        {
            Debug.LogWarning("PlayerHealth: No respawn point assigned!");
        }
    }
}
