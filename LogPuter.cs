using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogPuter : MonoBehaviour {

    public float Time_now = 0.0f;
    public int state = -1;
    public GameObject text01;
    public GameObject text02;
    public GameObject text03;
    public GameObject text04;
    //0で透明
    public float T_color =0;
    public float pos_def, posx;

    /*
     text01 = GameObject.Find("Text01");
     text02 = GameObject.Find("Text02");
     text03 = GameObject.Find("Text03");
     text04 = GameObject.Find("Text04");
     */
    void Start() {



    }

    // Update is called once per frame
    void Update()
    {
        


        Text Log01_text = text01.GetComponent<Text>();
        Text Log02_text = text02.GetComponent<Text>();
        Text Log03_text = text03.GetComponent<Text>();
        Text Log04_text = text04.GetComponent<Text>();
        Log01_text.color = new Color(0, 0, 0, T_color);
        Log01_text.color = new Color(0, 0, 0, T_color);
        Log01_text.color = new Color(0, 0, 0, T_color);
        Log01_text.color = new Color(0, 0, 0, T_color);

        Transform transform01 = text01.transform;
        Transform transform02 = text02.transform;
        Transform transform03 = text03.transform;
        Transform transform04 = text04.transform;
        //ここで設定
        Vector3 pos01 = text01.transform.position;
        if (state == -1) {
            pos_def = pos01.x;
            state++;
        }
        
        // pos.y -= 4.5f * Time.deltaTime;
        if (state == 0) {
            pos01.x = pos_def;//1-4
            Log01_text.text = "t";
            Log02_text.text = "e";
            Log03_text.text = "s";
            Log04_text.text = "t";

        } else if (state == 1 && Time_now >= 20.0f) {
            pos01.x = pos_def;//1-4
            Log01_text.text = " ";
            Log02_text.text = " ";
            Log03_text.text = " ";
            Log04_text.text = " ";
            state++;

        } else if (state == 3 && Time_now > 25.0f) {
            pos01.x = pos_def;//1-4
            Log01_text.text = "1";
            Log02_text.text = "2";
            Log03_text.text = "3";
            Log04_text.text = "4";
            state++;
        } else if (state == 5 && Time_now > 30.0f)
        {
            pos01.x = pos_def;//1-4
            Log01_text.text = "2";
            Log02_text.text = "2";
            Log03_text.text = "2";
            Log04_text.text = "2";
            state++;
        }
        else if (state == 7 && Time_now > 35.0f)
        {
            pos01.x = pos_def;//1-4
            Log01_text.text = "3";
            Log02_text.text = "3";
            Log03_text.text = "3";
            Log04_text.text = "3";
            state++;
        }
        else {

        }
        Time_now += Time.deltaTime;

        if (state == 0 || state == 2 || state == 4 || state == 6 || state == 8)
        {
            if (T_color < 1) {
                T_color +=  0.05f;
                pos01.x -= 0.5f;
                
            }
            else //if(T_color == 1)
            {
                T_color =0;
                state++;
            }
        }

        //text の場所を渡す
        text01.transform.position = pos01;
	}

}
/*
 how to play 
  1 tap notes
  let's tauch

     
     */