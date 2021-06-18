using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_Mode_Set : MonoBehaviour
{
    public static bool Auto_Mode = false;
    public Sprite On, Off;
    void Start()
    {
        if (Auto_Mode)
        {
            GetComponent<SpriteRenderer>().sprite = On;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = Off;
        }
    }
    void OnMouseDown()
    {
        if (Auto_Mode)
        {
            Auto_Mode = false;
            GetComponent<SpriteRenderer>().sprite = Off;
        }
        else
        {
            Auto_Mode = true;
            GetComponent<SpriteRenderer>().sprite = On;
        }
    }
    public static bool Get_Auto()
    {
        return Auto_Mode;
    }
}