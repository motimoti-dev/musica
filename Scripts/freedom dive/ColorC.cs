using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorC : MonoBehaviour {

    SpriteRenderer spriteRenderer;
    float a;
    int flac=0;
    void Start()
    {
        //エラーが出る場合.thisを付ける
        spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeTransparency(0); // 完全に透明にする
    }
    void Update () {
        if (flac == 0) {
            a = a + 0.003f;
        }
        else {
            a = a - 0.004f;
        }
        if (a > 1)
            flac = 1;
        if (a < -1)
            flac = 0;
        ChangeTransparency(a);
    }
    void ChangeTransparency(float a)
    {
        this.GetComponent<SpriteRenderer>().color = new Color(1,1,1,a);
    }
}
