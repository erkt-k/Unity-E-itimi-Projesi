using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> powerUps = new List<GameObject>();
    [SerializeField] private GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PowerUpCoroutine());
    }


    IEnumerator PowerUpCoroutine() {
        while(true) {
            yield return new WaitForSeconds(5f);
            int random = Random.Range(0,3);
            float x = Random.Range(-4.03f, 4.06f);
            GameObject powerUp = powerUps[random];
            Instantiate(powerUp, new UnityEngine.Vector3(x, transform.position.y, transform.position.z), transform.rotation, parent.transform);
        }
    }
}
