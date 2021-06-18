using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faster : MonoBehaviour {
    float fade;
    void Start()
    {
        fade = Time.time + 0.3f;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 100), "fast");
    }
    void Update()
    {
        if (fade <= Time.time)
        {
            Destroy(this.gameObject);
        }
    }
}

