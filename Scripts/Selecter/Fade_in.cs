using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade_in : MonoBehaviour {

    //SpriteRenderer spriteRenderer;
    float a =1;
    int end =0;
    void Start()
    {
        
        //this.spriteRenderer = GetComponent<SpriteRenderer>();
        //ChangeTransparency(1); // 完全に透明にする
    }
    void Update()
    {
        transform.position = new Vector3(Camera.main.gameObject.transform.position.x, Camera.main.gameObject.transform.position.y, 0.0f);
        if (end == 0)
        {
            a -= 0.01f;

            ChangeTransparency(a);
            if (a < 0)
            {
                end++;
            }
        }
    }
    void ChangeTransparency(float a)
    {
        this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, a);
    }
}
