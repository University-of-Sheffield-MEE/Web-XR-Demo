using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Label : MonoBehaviour
{
    public float heightAbove = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        GameObject parent = gameObject.transform.parent.gameObject;
        transform.position = parent.transform.position + Vector3.up * heightAbove;
        if (Camera.current != null) {
            transform.LookAt(Camera.current.transform.position);
            //transform.rotation = transform.rotation * Quaternion.Euler(0, 180, 0);
        }
    }
}
