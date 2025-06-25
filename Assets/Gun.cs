using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [Header("Gun Settings")]
    public float fireRate = 10f;
    public float bulletForce = 500f;
    public int maxAmmo = 10;
    public int currentAmmo;

    [Header("References")]
    public Transform bulletSpawner;
    public GameObject bulletPrefab;
    public ParticleSystem muzzleFlash;
    public AudioSource shootSound;
    public AudioSource reloadSound; //  Add this to play reload SFX
    public Text ammoText; // Assign your UI Text in the Inspector

    private float nextTimeToFire = 0f;

    void Start()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoUI();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && currentAmmo > 0)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    void Shoot()
    {
        currentAmmo--;
        UpdateAmmoUI();

        if (muzzleFlash != null) muzzleFlash.Play();
        if (shootSound != null) shootSound.Play();

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawner.position + bulletSpawner.forward * 0.5f, bulletSpawner.rotation);
        Destroy(bullet, 10f);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(bulletSpawner.forward * bulletForce, ForceMode.Impulse);
        }
    }

    void Reload()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoUI();

        if (reloadSound != null)
        {
            reloadSound.Play(); //  Play reload sound here
        }

        Debug.Log("Reloaded!");
    }

    void UpdateAmmoUI()
    {
        if (ammoText != null)
            ammoText.text = $"{currentAmmo} / {maxAmmo}";
    }
}
