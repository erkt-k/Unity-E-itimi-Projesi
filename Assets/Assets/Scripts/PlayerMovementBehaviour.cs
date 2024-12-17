using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    private Transform trans;

    public float playerSpeed;

    [SerializeField] private int lives = 3;
    [SerializeField] private GameObject shield;
    private bool isShieldActive = false;

    
    /*
    float xAngle;
    float yAngle;
    float zAngle;

    public float xScale;
    public float yScale;
    public float zScale;
    */

    // Start is called before the first frame update
    void Start()
    {
        //trans = GetComponent<Transform>(); // değişken ismi = GetComponent<KomponentTürü>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //trans.Rotate(xAngle, yAngle, zAngle);
        //trans.localScale = trans.localScale + new Vector3(xScale, yScale, zScale);
        HandleMovement();

        if (lives <= 0) {
            Destroy(this.gameObject);
        }
    }

    public void HandleMovement() {
        float horizontal = Input.GetAxis("Horizontal");
        Debug.Log("Horizontal: " + horizontal);

        transform.Translate(playerSpeed * horizontal * Time.deltaTime, 0, 0);

        //Practice Solution
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(0, playerSpeed * vertical * Time.deltaTime, 0);
        float clampedY = Mathf.Clamp(transform.position.y, -1.16f, 3.12f);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);

        if (transform.position.x < -6.24f) {
            transform.position = new Vector3(6.24f , transform.position.y, transform.position.z);
        } else if (transform.position.x > 6.24f) {
            transform.position = new Vector3(-6.24f, transform.position.y, transform.position.z);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            if (!(isShieldActive)) {
                lives--;
            } else {
                isShieldActive = false;
                shield.SetActive(false);
            }
        } else if (other.CompareTag("Shield")) {
            shield.SetActive(true);
            isShieldActive = true;
            Destroy(other.gameObject);
        } 
    }
}