using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float damage = 10f;
    public float lifetime = 3f;

    void Start()
    {
        Destroy(gameObject, lifetime); // destroy after a few seconds
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Try to damage object
        EnemyTarget target = collision.transform.GetComponent<EnemyTarget>();
        if (target != null)
        {
            target.TakeDamage(damage);
        }

        Destroy(gameObject); // destroy bullet on hit
    }
}
