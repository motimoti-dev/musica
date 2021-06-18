using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class AppearingTools : MonoBehaviour
{
    public string ToolsState;
    public GameObject Pointer;
    private GameObject Txt1, Txt2, Txt3,NameSound;
    // Use this for initialization
    void Start()
    {
        ToolsState = "close";
        Pointer = Camera.main.gameObject;
        Txt1 = Pointer.transform.Find("Canvas").transform.Find("1st").gameObject;
        Txt2 = Pointer.transform.Find("Canvas").transform.Find("2nd").gameObject;
        Txt3 = Pointer.transform.Find("Canvas").transform.Find("3rd").gameObject;
        if (SceneManager.GetActiveScene().name != "advance")
        {
            NameSound = Pointer.transform.Find("Canvas").transform.Find("SOUND_NAME").gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //これがアクセスされたら展開する
    public void Open()
    {
        Debug.Log("tools try to open");
        //もし既に開いていたら追加オプションを表示する
        if (ToolsState == "close")
        {
            Debug.Log("left");
            this.GetComponent<Transform>().DOMoveX(Pointer.transform.position.x - 5.2f, 0.3f)
                .SetEase(Ease.InExpo);
            ToolsState = "Open";
            Txt1.GetComponent<Text_1st>().Set_Pos(true);
            Txt2.GetComponent<Text_2nd>().Set_Pos(true);
            Txt3.GetComponent<Text_3rd>().Set_Pos(true);
            if (SceneManager.GetActiveScene().name != "advance")
            {
                NameSound.GetComponent<SOUND_NAME_C>().Set_Pos(true);

            }
        }
        else
        {
            Debug.Log("Opened already");
        }
    }

    public void Close ()
    {
        Debug.Log("tools try to close");
        //もし既に開いていたら追加オプションを表示する
        if (ToolsState == "Open")
        {
            Debug.Log("left");
            this.GetComponent<Transform>().DOMoveX(Pointer.transform.position.x - 13f, 0.3f)
                .SetEase(Ease.InExpo);
            ToolsState = "close";
            Txt1.GetComponent<Text_1st>().Set_Pos(false);
            Txt2.GetComponent<Text_2nd>().Set_Pos(false);
            Txt3.GetComponent<Text_3rd>().Set_Pos(false);
            NameSound.GetComponent<SOUND_NAME_C>().Set_Pos(false);
        }
        else
        {
            Debug.Log("Closed already");
        }
    }
    public bool Get_State()
    {
        if (ToolsState == "Open")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

