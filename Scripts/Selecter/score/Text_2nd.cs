using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_2nd : MonoBehaviour {

    Text text_2nd;
    string Score;
    // Use this for initialization
    void Start()
    {
        Score = "1000";
        text_2nd = GetComponentInChildren<Text>();
        text_2nd.text = "2nd  " + Score;
    }

    public void ScoreChanger(int New_Score)
    {

        text_2nd.text = "2nd  " + New_Score;

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
