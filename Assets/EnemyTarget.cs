using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    public int health = 100;
    public void Start()
    {
    }
    public void TakeDamage(int damageAmount)
    {
        EnemySpawner spawner = FindObjectOfType<EnemySpawner>();
        health -= damageAmount;
        Debug.Log($"Enemy hit! Took {damageAmount} damage. Remaining HP: {health}");

        if (health <= 0)
        {
            spawner.OnEnemyDestroyed();
            Die();
        }
    }


    void Die()
    {
        Debug.Log("Enemy died!");
        Destroy(gameObject);
    }
}
