using UnityEngine;

public class CooldownSystem : MonoBehaviour
{
    public GameObject projectilePrefab;  // The projectile prefab
    public Transform firePoint;         // The position where the projectile spawns
    public float cooldownTime = 2.0f;   // Cooldown time in seconds

    private float nextFireTime = 0f;    // Tracks when the player can fire next

    void Update()
    {
        // Check if the player presses the Fire key (space) and cooldown has elapsed
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Fire();
        }
    }

    void Fire()
    {
        // Instantiate the projectile
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Set the next allowed fire time
        nextFireTime = Time.time + cooldownTime;
    }
}
