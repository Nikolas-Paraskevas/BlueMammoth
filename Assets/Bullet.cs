using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 10;

    private void Start()
    {
        Destroy(gameObject, 5f); // Destroy bullet after 5 seconds to prevent clutter
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            EnemyTarget enemy = collision.gameObject.GetComponent<EnemyTarget>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
