using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Gun Settings")]
    public float fireRate = 10f;
    public float bulletForce = 500f;

    [Header("References")]
    public Transform bulletSpawner;          // Where bullets spawn from
    public GameObject bulletPrefab;          // The bullet prefab to shoot
    public ParticleSystem muzzleFlash;       // Optional: muzzle flash effect
    public AudioSource shootSound;           // Optional: gunshot sound

    private float nextTimeToFire = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        // Visual & sound effects
        if (muzzleFlash != null) muzzleFlash.Play();
        if (shootSound != null) shootSound.Play();

        // Spawn the bullet
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);

        // Destroy bullet after 10 seconds
        Destroy(bullet, 10f);

        // Apply forward force if Rigidbody exists
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(bulletSpawner.forward * bulletForce, ForceMode.Impulse);
        }
    }
}

