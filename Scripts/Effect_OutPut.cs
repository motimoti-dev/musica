using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Effect_OutPut : MonoBehaviour {
    private float Time_t, reset_time = 0.5f;
    private Vector3 pos;
    private bool mode = false;
    private GameObject Scorer;
    private void Start()
    {
        GetComponent<Text>().text = "";
        Scorer = Camera.main.GetComponent<Object_Relay>().Get_ScoreManager();
    }
    public void Effect_Out_Put(int t)
    {
        switch (t)
        {
            //各種スコア処理未移行
            case 0:
                //Critical
                Scorer.GetComponent<scoreC>().Critical();
                GetComponent<Text>().text = "Critical";
                GetComponent<Text>().color = new Color32(255, 255, 0, 255);
                break;
            case 1:
                //Hit
                Scorer.GetComponent<scoreC>().Hit();
                GetComponent<Text>().text = "Hit";
                GetComponent<Text>().color = new Color32(0, 255, 0, 255);
                break;
            case 2:
                //Miss
                Scorer.GetComponent<scoreC>().Miss();
                GetComponent<Text>().text = "Miss";
                GetComponent<Text>().color = new Color32(0, 0, 255, 255);
                break;
            default:
                GetComponent<Text>().text = "";
                break;
        }
        if (mode)
        {
            transform.position = pos;
        }
        else
        {
            mode = true;
            pos = transform.position;
        }
        transform.GetChild(0).GetComponent<UI_Child_Shadow>().Child_Shadow_Set();
        Time_t = 0;
    }
    private void Update()
    {
        if (Time.timeScale != 0) {
            if (mode)
            {
                Time_t += Time.deltaTime;
                Vector3 Pos = transform.position;
                Pos.y += Screen.height * 0.005f;
                transform.position = Pos;
                if (Time_t > reset_time)
                {
                    GetComponent<Text>().text = "";
                    transform.position = pos;
                    transform.GetChild(0).GetComponent<UI_Child_Shadow>().Child_Shadow_Set();
                    mode = false;
                }
            }
        }
    }
}
