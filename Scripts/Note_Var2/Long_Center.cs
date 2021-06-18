using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Long_Center : MonoBehaviour {
    public Vector3 Size;
    void Update()
    {
        Size = transform.lossyScale;
    }
}