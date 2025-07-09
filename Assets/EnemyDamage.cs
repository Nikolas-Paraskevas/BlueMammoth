using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damageInterval = 2f;
    public float damageAmount = 10f;
    public float damageRange = 2f;
    public Transform player;

    private float timer = 0f;

    void Start()
    {
        // Auto-assign player if not manually set
        if (player == null)
        {
            GameObject foundPlayer = GameObject.FindGameObjectWithTag("Player");
            if (foundPlayer != null)
            {
                player = foundPlayer.transform;
                Debug.Log("EnemyDamage: Player found automatically.");
            }
            else
            {
                Debug.LogWarning("EnemyDamage: Player not assigned and not found in scene.");
            }
        }
    }

    void Update()
    {
        if (player == null)
            return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= damageRange)
        {
            timer += Time.deltaTime;

            if (timer >= damageInterval)
            {
                ApplyDamage();
                timer = 0f;
            }
        }
        else
        {
            timer = 0f; // Reset timer if out of range
        }
    }

    void ApplyDamage()
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            Debug.Log("EnemyDamage: Applying " + damageAmount + " damage to player.");
            playerHealth.TakeDamage(damageAmount);
        }
        else
        {
            Debug.LogWarning("EnemyDamage: PlayerHealth script not found on player.");
        }
    }
}
