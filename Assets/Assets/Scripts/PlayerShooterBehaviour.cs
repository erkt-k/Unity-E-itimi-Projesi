using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooterBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject projectileParent;
    [SerializeField] private GameObject projectilePrefab;  // The projectile prefab

    [SerializeField] private GameObject tripleLaser;
    private bool isTripleLaserActive = false;
    
    [SerializeField] private float Cooldown = 2f;
    [SerializeField] private float nextFireTime = 0f;    // Tracks when the player can fire next

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            if (isTripleLaserActive) {
                Instantiate(tripleLaser, transform.position, transform.rotation, projectileParent.transform);
                nextFireTime = Time.time + Cooldown;
            } else {
                Instantiate(projectilePrefab, transform.position, transform.rotation, projectileParent.transform);
                nextFireTime = Time.time + Cooldown;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Triple Laser")) {
            isTripleLaserActive = true;
            StartCoroutine(tripleLaserCoroutine());
        } else if (other.CompareTag("Enemy")) {
            isTripleLaserActive = false;
        }
    }

    IEnumerator tripleLaserCoroutine() {
        yield return new WaitForSeconds(5f);
        isTripleLaserActive = false;
    }
}
