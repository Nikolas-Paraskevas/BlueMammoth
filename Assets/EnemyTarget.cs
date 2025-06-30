using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    public int health = 100;
    public EnemySpawner spawner;

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        Debug.Log($"Enemy hit! Took {damageAmount} damage. Remaining HP: {health}");

        if (health <= 0)
        {
            Die();
        }
    }


    void Die()
    {
        Debug.Log("Enemy died!");

        if (spawner != null)
        {
            spawner.OnEnemyDestroyed(transform.position);
        }

        Destroy(gameObject);

    }
}
