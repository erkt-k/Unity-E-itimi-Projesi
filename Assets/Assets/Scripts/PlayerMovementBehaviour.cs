using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    private Transform trans;

    public float playerSpeed;

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
    }

    public void HandleMovement() {
        float horizontal = Input.GetAxis("Horizontal");
        Debug.Log("Horizontal: " + horizontal);

        transform.Translate(playerSpeed * horizontal * Time.deltaTime, 0, 0);

        //To do
        // Karakteri ekrana sınırla
    }
}