using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    [SerializeField] private float laserSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,laserSpeed * Time.deltaTime,0);
        if (transform.position.y >= 8f) {
            Destroy(this.gameObject, 2f);
        }
    }
}
