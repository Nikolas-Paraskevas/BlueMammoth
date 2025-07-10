using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public int lives = 3;
    private float currentHealth;

    public Slider healthBarSlider;
    public Transform respawnPoint; // Assign in Inspector or dynamically
    public Text livesText;
    public Text healthText;
    public AudioSource deathSound;
    public AudioSource damageSound;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateLivesUI();
        UpdateHealthUI();

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
        damageSound.Play();
        UpdateHealthUI();
        Debug.Log("PlayerHealth: Took " + amount + " damage. Health now: " + currentHealth);

        if (healthBarSlider != null)
        {
            healthBarSlider.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            if (lives > 1)
            {
                lives--;
                Die();
                UpdateLivesUI();
            }
            else
            {
                Debug.Log("You lost");
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("Assets/DeathScene.unity");
            }
        }
    }

    void Die()
    {
        deathSound.Play();
        Debug.Log("PlayerHealth: Player died.");
        Respawn();
    }

    void Respawn()
    {
        Debug.Log("PlayerHealth: Respawning...");
        currentHealth = maxHealth;
        UpdateHealthUI();

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

    void UpdateLivesUI()
    {
        if (livesText != null)
            livesText.text = $"{lives} / 3";
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
            healthText.text = $"{currentHealth} / {maxHealth}";
    }
}
