using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    private Transform trans;
    public float xAngle;
    public float yAngle;
    public float zAngle;

    public float xScale;
    public float yScale;
    public float zScale;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        trans.Rotate(xAngle, yAngle, zAngle);
        trans.localScale += new Vector3(xScale, yScale, zScale);    
    }
}