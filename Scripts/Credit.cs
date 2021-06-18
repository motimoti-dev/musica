using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
[ExecuteInEditMode]
public class Credit : MonoBehaviour
{
    [Header("横の長さ全体を100としたときの値(左が0)")] [Range(0, 1000)] public int Pos_x = 0;
    [Header("縦の長さ全体を100としたときの値(下が0)")] [Range(0, 10000)] public int Pos_y = 0;
    [Header("文字の大きさ(Screen.width100の時100で10になる)")] [Range(1, 1500)] public int Font_Size = 1;
    [Header("画像なら真に")]public bool Sp = false;
    [Header("画像の大きさX")][Range(1,1000)] public float Size = 1;

    void Update()
    {
        if (!Sp)
        {
            GetComponent<Text>().fontSize = Convert.ToInt32(Screen.width * Font_Size / 1000.0f);
            GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<Text>().preferredWidth, GetComponent<Text>().preferredHeight);
        }
        else
        {
            transform.localScale = new Vector2(Size / 10000.0f * Screen.width, Size / 10000.0f * Screen.width);
        }
        transform.position = new Vector2(Pos_x / 1000.0f * Screen.width, Pos_y / 1000.0f * Screen.height);   
    }
}
