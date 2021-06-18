using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
//中心の箱たちのイージング

public class Cube_Easing : MonoBehaviour {
    //オリジナルの箱
    public GameObject Cube_O;
    public int flac,flac1 = 0;
    int Mode = 0;
    int Mode_before = -1;
    float pos_x;
    void Start()
    {
        pos_x = this.transform.position.x;
        
        //gameObject取得 
        Cube_O = Camera.main.transform.Find("Cube").gameObject;
        //今の色コンソールに出力
        Debug.Log(this.GetComponent<Renderer>().material.color);
        turquoise();
    }

    public void ColorChange() {
        //色合わせ Mode変更の0.2秒後ぐらいに呼んで
        this.GetComponent<Renderer>().material.color = Cube_O.GetComponent<Renderer>().material.color;
    }

    public void Update()
    {
     
        Mode = Cube_O.GetComponent<Box_roll>().Mode_Now();
        if (Mode != Mode_before) {
            //モード変更の検知
            Invoke("ColorChange",0.2f);
            Mode_before = Mode;
            Debug.Log("Mode Changed");
        }

        
        this.transform.Rotate(new Vector3(2, 4, 0.7f));

        
    }
    public void pastel_green()
    {

        this.GetComponent<Renderer>().material.color = new Color(25, 255, 25, 1);

    }

    public void turquoise()
    {
        this.GetComponent<Renderer>().material.color = new Color(25, 25, 255, 1);
    }

    public void black()
    {

        this.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1);

    }

    public void pink()
    {

        this.GetComponent<Renderer>().material.color = new Color(255, 25, 25, 1);

    }

    
}
