using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sway : MonoBehaviour {

    // Update is called once per frame
    public float amplitude = 0.01f;
    public int range = 10000;
    private int frameCnt = 0;

    void FixedUpdate() {
        frameCnt += 1;
        if (range <= frameCnt) {
            frameCnt = 0;
        }
        if (0 == frameCnt%2) {
            float posYSin = Mathf.Sin(2.0f * Mathf.PI * (float)(frameCnt % 200) / (200.0f - 1.0f));
            iTween.MoveAdd(gameObject, new Vector3(0, amplitude * posYSin, 0), 0.0f);

        }
    }
}
