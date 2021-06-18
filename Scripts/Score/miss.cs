using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miss : MonoBehaviour {
    float fade;
    GameObject scorec;
    void Start()
    {
        fade = Time.time + 0.2f;
        scorec = GameObject.Find("ScoreManager");
        scorec.GetComponent<scoreC>().Miss();
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 100), "miss");
    }
    void Update()
    {
        if (fade <= Time.time)
        {
            Destroy(this.gameObject);
        }
    }
}
