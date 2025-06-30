using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class laser : MonoBehaviour
{
    public float rayDistance = 10f;
    public Vector3 rayDirection = Vector3.forward;

    void Start()
    {
    }

    void Update()
    {
        Vector3 direction = transform.TransformDirection(rayDirection);
        Ray ray = new Ray(transform.position, direction);
        RaycastHit hit;
        EnemySpawner spawner = FindObjectOfType<EnemySpawner>();
        Enemy enemy = FindObjectOfType<Enemy>();

        Debug.DrawRay(transform.position, direction * rayDistance, Color.red);

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            Debug.Log("Hit: " + hit.collider.name);

            if (hit.collider.CompareTag("Enemy"))
            {
                enemy.TakeDamage(50);
                if (enemy.health == 0)
                {
                    if (spawner != null)
                    {
                        spawner.OnEnemyDestroyed();
                    }
                    Destroy(hit.collider.gameObject);
                    Debug.Log("Enemy destroyed!");
                }
                
            }
        }
    }
}
