using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UI_Pos_Auto_Set : MonoBehaviour
{
    [Header("横の長さ全体を100としたときの値(左が0)")] [Range(0, 1000)] public int Pos_x = 0;
    [Header("縦の長さ全体を100としたときの値(下が0)")] [Range(0, 1000)] public int Pos_y = 0;
    [Header("文字の大きさ(Screen.width100の時100で10になる)")] [Range(1, 1500)] public int Font_Size = 1;
    [Header("ボタンなら真に")] public bool button = false;
    [Header("テキストがあるなら真に(ボタンの子供も対象)")] public bool text = false;
    [Header("テキスト以外の横の大きさ(画面全体の大きさが100)")] [Range(1, 100)] public int Size_x = 1;
    [Header("テキスト以外の縦の大きさ(画面全体の大きさが100)")] [Range(1, 100)] public int Size_y = 1;
    void Start()
    {
        transform.position = new Vector2(Pos_x / 1000.0f * Screen.width, Pos_y / 1000.0f * Screen.height);
        if (text)
        {
            if (button)
            {
                transform.GetChild(0).GetComponent<Text>().fontSize = Convert.ToInt32(Screen.width * Font_Size / 1000.0f);
            }
            else
            {
                GetComponent<Text>().fontSize = Convert.ToInt32(Screen.width * Font_Size / 1000.0f);
            }
        }
        if (button)
        {
            GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width * Size_x / 100.0f, Screen.height * Size_y / 100.0f);
        }
    }
    void Update()
    {
        if (text)
        {
            if (button)
            {
                transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector3(transform.GetChild(0).GetComponent<Text>().preferredWidth, transform.GetChild(0).GetComponent<Text>().preferredHeight);
            }
            else
            {
                GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<Text>().preferredWidth, GetComponent<Text>().preferredHeight);
            }
        }
        /*
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("押した瞬間");
            }
            if (touch.phase == TouchPhase.Ended)
            {
                Debug.Log("話した瞬間");
            }
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 tpos = touch.position;
                Debug.Log("押しっぱ");
            }
        }*/
    }
}