using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private float enemySpeed = -5f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }

    public void Move() {
        transform.Translate(0, enemySpeed * Time.deltaTime, 0);

        if (transform.position.y < -2.73f) {
            float x = Random.Range(-4.03f, 4.06f);
            transform.position = new Vector3(x, 6.6f, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Laser")) {    
            enemySpeed = 0;
            Destroy(this.gameObject);
        }
    }
}
