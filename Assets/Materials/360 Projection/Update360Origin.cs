using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Update360Origin : MonoBehaviour
{
    public Material material;
    public Cubemap image;

    void Update()
    {
        material.SetMatrix("_panoramaOrigin", transform.worldToLocalMatrix);
        material.SetTexture("_MainTex", image);
    }
}