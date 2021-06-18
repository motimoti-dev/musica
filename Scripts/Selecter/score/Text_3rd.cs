using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_3rd : MonoBehaviour {

    Text text_3rd;
    string Score;
    // Use this for initialization
    void Start()
    {
        Score = "1000";
        text_3rd = GetComponentInChildren<Text>();
        text_3rd.text = "3rd  " + Score;
    }

    public void ScoreChanger(int New_Score)
    {

        text_3rd.text = "3rd  " + New_Score;

    }
    public void Set_Pos(bool Open)
    {
        if (Open)
        {
            Vector3 pos = transform.position;
            pos.z = -10.0f;
            transform.position = pos;
        }
        else
        {
            Vector3 pos = transform.position;
            pos.z = 1.0f;
            transform.position = pos;
        }
    }
}
