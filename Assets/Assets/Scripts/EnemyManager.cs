using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(dusmanlarıDogur());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator dusmanlarıDogur() {
        while (true) {
        yield return new WaitForSeconds(3f);
        float x = Random.Range(-4.03f, 4.06f);
        Instantiate(enemyPrefab, new UnityEngine.Vector3(x, transform.position.y, transform.position.z), UnityEngine.Quaternion.identity);
        }
    } 
}
