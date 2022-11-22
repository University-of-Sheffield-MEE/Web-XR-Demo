using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class OrbitCamera : MonoBehaviour
{
    public Transform orbitPosition;
    public float orbitSpeed = 10; 
    public float zoomSpeed = 1;
    public float distance = 0;

    private Vector2 orbitAngles = new Vector2(0f, 0f);

    void Start()
    {
        if (distance == 0) {
            distance = (orbitPosition.position - transform.position).magnitude;
        }
        Vector3 euler = transform.eulerAngles;
        orbitAngles[0] = euler[0];
        orbitAngles[1] = euler[1];
    }

    void Update()
    {
        float deltaAngle = Time.deltaTime * orbitSpeed * 180f / Mathf.PI;

        Vector2 input = new Vector2(
			Input.GetAxis("Vertical"),
			-Input.GetAxis("Horizontal")
		);
        orbitAngles += deltaAngle * input;
        if (orbitAngles[0] > 90) {
            orbitAngles[0] = 90;
        }
        if (orbitAngles[0] < -90) {
            orbitAngles[0] = -90;
        }

        distance -= zoomSpeed * Input.GetAxis("Mouse ScrollWheel");
        if (distance < 0) {
            distance = 0;
        }

        Quaternion orbitQuat = Quaternion.Euler(orbitAngles);
		Vector3 orbitDir = orbitQuat * Vector3.forward;
		Vector3 position = orbitPosition.position - orbitDir * distance;
		transform.SetPositionAndRotation(position, orbitQuat);
    }
}
