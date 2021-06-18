using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_roll : MonoBehaviour
{

    public GameObject myCube;
    public GameObject Cube_O;
    public GameObject Cube_Easing;
    public int Mode = 0;
    int Mode_before = -1;
    // Use this for initialization
    void Start()
    {
        
        //gameObject取得 
        myCube = Cube_O = Camera.main.transform.Find("Cube").gameObject;

        //今の色コンソールに出力
        Debug.Log(myCube.GetComponent<Renderer>().material.color);



        //ピンク
        //myCube.GetComponent<Renderer>().material.color = new Color(255,25, 25, 1); 
        //ほかの部分を変更すると時用
        //myCube.GetComponent<Renderer>().material.SetColor("_MainTex",new Color (1,1,1,1)); 

        //変更後の色コンソールに出力
        Debug.Log(myCube.GetComponent<Renderer>().material.color);
    }
    //いまのモードを返す通常時　0
    //0 easy 1 nomal 2 hard 3 turn反転
    public int Mode_Now() {

        return Mode;
    }
    //0-3までの整数値の設定
    public void Mode_Change(int a)
    {
        Mode = a;

    }
    public void pastel_green()
    {

        myCube.GetComponent<Renderer>().material.color = new Color(25, 255, 25, 1);

    }

    public void turquoise()
    {
        myCube.GetComponent<Renderer>().material.color = new Color(25, 25, 255, 1);
    }

    public void black()
    {

        myCube.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1);

    }

    public void pink()
    {

        myCube.GetComponent<Renderer>().material.color = new Color(255, 25, 25, 1);

    }

    
    void Update()
    {
        transform.Rotate(new Vector3(2, 4, 0.7f));
        Mode = Cube_O.GetComponent<Box_roll>().Mode_Now();
        if (Mode != Mode_before)
        {
            //モード変更の検知

            Mode_before = Mode;
            Debug.Log("Mode Changed (roll)");
        }
    }
}
