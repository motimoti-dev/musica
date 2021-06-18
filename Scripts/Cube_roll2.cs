using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_roll2 : MonoBehaviour {

    public GameObject Cube_O;
    int Mode = 0;
    int Mode_before = -1;
    private void Start()
    {
        //gameObject取得 
        Cube_O = Camera.main.transform.Find("Cube").gameObject;
        this.GetComponent<Renderer>().material.color = new Color(25, 25, 255, 1);
        Vector3 pos = (transform.parent.transform.parent.transform.Find("Boader_Cube1")).GetComponent<Renderer>().bounds.center;
    }

    // Update is called once per frame
    void Update () {
        this.transform.Rotate(new Vector3(1,1, 1));
        Transform transform = this.transform;
        Vector3 pos = transform.position;
        //ここで座標変更
        transform.position = pos;
        Mode = Cube_O.GetComponent<Box_roll>().Mode_Now();
        if (Mode != Mode_before)
        {
            //モード変更の検知

            Mode_before = Mode;
            Invoke("ColorChange", 0.2f);
            Debug.Log("Mode Changed (roll2)");
        }
    }

    public void ColorChange()
    {
        //色合わせ Mode変更の0.2秒後ぐらいに呼んで
        this.GetComponent<Renderer>().material.color = Cube_O.GetComponent<Renderer>().material.color;
    }
}
