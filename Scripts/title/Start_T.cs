using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Start_T : MonoBehaviour
{
    Text myText;
    int turn = 0;
    float a = 0;

    // Use this for initialization
    void Start()
    {
        myText = GetComponentInChildren<Text>();//UIのテキストの取得の仕方
        myText.text = "Tap to start";

    }

    public void fade()
    {
        Debug.Log("start");
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (a > 1)
            turn = 1;
        if (a < 0)
            turn = 0;
        if (turn == 0)
            a += 0.05f;
        if (turn == 1)
            a -= 0.03f;
        myText.color = new Color(0,0,0,a);

    }
    
}
