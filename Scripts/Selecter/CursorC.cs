using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorC : MonoBehaviour {

    public Texture A;
    public Texture B;
    public Texture C;
    public Texture D;
    public Texture Extra;
    public Texture Back;
	void Start () {
		
	}
	
	void Update () {
		Transform transform = this.transform;
        Vector3 pos = transform.position;
        //pos.y -= 10f * Time.deltaTime;    // x座標へ0.01加算
        if (Input.GetKey("d"))
        {
            pos.x = 18;
        }
        if (Input.GetKey("w"))
        {
            pos.y = 10;
        }
        if (Input.GetKey("a"))
        {
            pos.x = -18;
        }
        if (Input.GetKey("z"))
        {
            pos.y = -10;
        }
        if (Input.GetKey("s"))
        {
            pos.x = 0;
            pos.y = 0;
        }
 

        transform.position = pos;  // 座標を設定

	}
    /*void OnGUI()
    {
        // ボタンを表示する
        if (GUI.Button(new Rect(50, 400, 60, 30), "back"))
        {
            Debug.Log("Button is clicked.");

        }
        if (GUI.Button(new Rect(50, 30, 30, 30), A))
        {
            Debug.Log("Button is clicked.");

        }
        if (GUI.Button(new Rect(50, 70, 30, 30), "B"))
        {
            Debug.Log("Button is clicked.");

        }
        if (GUI.Button(new Rect(50, 110, 30, 30), "C"))
        {
            Debug.Log("Button is clicked.");

        }
        if (GUI.Button(new Rect(50, 150, 30, 30), "D"))
        {
            Debug.Log("Button is clicked.");

        }
    }*/

}
