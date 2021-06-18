using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Relay : MonoBehaviour {
    public GameObject Music_Play, PauseUI, Effecter, Note, ScoreManager;
    public GameObject Get_PlayC()
    {
        return Music_Play;
    }
    public GameObject Get_PauseUI()
    {
        return PauseUI;
    }
    public GameObject Get_Effecter()
    {
        return Effecter;
    }
    public GameObject Get_Note()
    {
        return Note;
    }
    public GameObject Get_ScoreManager()
    {
        return ScoreManager;
    }

}