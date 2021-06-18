using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SOUND_NAME_C : MonoBehaviour
{

    Text text;
    string SOUND;
    // Use this for initialization
    void Start()
    {
        SOUND = "NoName";
        text = GetComponentInChildren<Text>();
        text.text = SOUND;
    }
    public string ChangeName(string NewName)
    {
        text.text = NewName;
        return NewName;
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