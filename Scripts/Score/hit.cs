using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour {
    float fade;
    GameObject scorec;

    public void Start()
    {
        scorec = GameObject.Find("ScoreManager");
        fade = Time.time + 0.3f;
        scorec.GetComponent<scoreC>().Hit();
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 100), "good");
    }
    void Update()
    {
        if (fade <= Time.time)
        {
            Destroy(this.gameObject);
        }
    }
}
