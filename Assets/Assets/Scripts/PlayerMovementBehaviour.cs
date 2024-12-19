using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerMovementBehaviour : MonoBehaviour
{
    private Transform trans;

    [SerializeField] private float playerSpeed;
    [SerializeField] private float speedBoost;

    [SerializeField] private int lives = 3;
    [SerializeField] private List<Sprite> liveImage = new List<Sprite>();
    [SerializeField] private Image image;
    [SerializeField] private GameObject shield;

    private int score = 0;
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    private bool isShieldActive = false;

    private Animator anim;

    [SerializeField] private AudioSource powerUpSound;

    
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
        anim = GetComponent<Animator>();
        image.sprite = liveImage[lives];
        scoreText.text = score.ToString();
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

        if(horizontal > 0) {
            anim.SetBool("isTurningRight", true); //isTurningRight = true;
            anim.SetBool("isTurningLeft", false); //isTurningLeft = false;
        } else if (horizontal == 0) {
            anim.SetBool("isTurningRight", false); //isTurningRight = true;
            anim.SetBool("isTurningLeft", false); //isTurningLeft = false;
        } else if (horizontal < 0) {
            anim.SetBool("isTurningLeft", true);
            anim.SetBool("isTurningRight", false);
        }

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

    public void IncreaseScore() {
        score += 50;
        scoreText.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            if (!(isShieldActive)) {
                lives--;
                image.sprite = liveImage[lives];
            } else {
                isShieldActive = false;
                shield.SetActive(false);
            }
        } else if (other.CompareTag("Shield")) {
            powerUpSound.Play();
            shield.SetActive(true);
            isShieldActive = true;
            Destroy(other.gameObject);
        } else if (other.CompareTag("Speed")) {
            powerUpSound.Play();
            playerSpeed += speedBoost;
            StartCoroutine(SpeedBoostCoroutine());
            Destroy(other.gameObject);
        }
    }

    IEnumerator SpeedBoostCoroutine() {
        yield return new WaitForSeconds(5f);
        playerSpeed -= speedBoost;
    }
}