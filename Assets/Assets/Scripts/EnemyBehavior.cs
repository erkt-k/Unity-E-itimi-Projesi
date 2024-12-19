using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private float enemySpeed = -5f;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
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
            anim.SetBool("isDed", true);
            player.GetComponent<PlayerMovementBehaviour>().IncreaseScore();
            Destroy(this.gameObject, 2.38f);
        }
    }
}
