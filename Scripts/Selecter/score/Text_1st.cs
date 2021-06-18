using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_1st : MonoBehaviour {

    Text text_1st;
    string Score;
    // Use this for initialization
    void Start()
    {
        Score = "1000";
        text_1st = GetComponentInChildren<Text>();
        text_1st.text = "1st  " + Score;
    }

    public void ScoreChanger(int New_Score) {

        text_1st.text = "1st  " + New_Score;

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
