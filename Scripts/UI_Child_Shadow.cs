using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Child_Shadow : MonoBehaviour
{
    private Vector3 Pos;
    private int fontsize;
    public int xSlip = 0, ySlip = 0;
    public Color32 color;
    void Start()
    {
        Pos = transform.parent.transform.position;
        GetComponent<Text>().fontSize = transform.parent.GetComponent<Text>().fontSize;
        Pos.x += (Screen.width * xSlip / 1000.0f);
        Pos.y += (Screen.width * ySlip / 1000.0f);
        transform.position = Pos;
        GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<Text>().preferredWidth, GetComponent<Text>().preferredHeight);
        GetComponent<Text>().color = color;
    }
    public void Child_Shadow_Set()
    {
        Pos = transform.parent.transform.position;
        GetComponent<Text>().fontSize = transform.parent.GetComponent<Text>().fontSize;
        Pos.x += (Screen.width * xSlip / 1000.0f);
        Pos.y += (Screen.width * ySlip / 1000.0f);
        transform.position = Pos;
        GetComponent<Text>().color = color;
        GetComponent<Text>().text = transform.parent.GetComponent<Text>().text;
    }
    private void Update()
    {
        if (GetComponent<Text>().text != transform.parent.GetComponent<Text>().text)
        {
            Child_Shadow_Set();
        }
        GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<Text>().preferredWidth, GetComponent<Text>().preferredHeight);
    }
}
