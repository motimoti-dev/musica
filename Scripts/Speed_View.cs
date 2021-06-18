using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Speed_View : MonoBehaviour
{
    Vector3 Pos;
    public static float Speed = 10.0f;
    public GameObject Note;
    private float Time_t;
    public float Span = 1.0f;
    private GameObject Camera_Object;
    private GameObject Tolls;
    private Vector3 MousePos;
    public static bool Auto = false;
    //Speed:5～20まで
    void Update()
    {
        if (transform.parent.transform.parent.GetComponent<AppearingTools>().Get_State())//toolが開かれているか
        {
            if (Input.GetKeyDown("k"))
            {
                if (Speed != 20)
                {
                    Speed++;
                    Pos = transform.localPosition;
                    Pos.y = (Speed - 5) * (1.0f / 15.0f) - 0.5f;
                    transform.localPosition = Pos;
                }
            }
            else if (Input.GetKeyDown("l"))
            {
                if (Speed != 5)
                {
                    Speed--;
                    Pos = transform.localPosition;
                    Pos.y = (Speed - 5) * (1.0f / 15.0f) - 0.5f;
                    transform.localPosition = Pos;
                }
            }
            Time_t += Time.deltaTime;
            if (Time_t >= Span)
            {
                GameObject temp = Instantiate(Note, new Vector3(-5.0f + Camera_Object.transform.position.x, 5.0f + (Speed - 4) + Camera_Object.transform.position.y, 0.0f), transform.rotation);
                temp.GetComponent<Spedd_View_Note>().Set_S(Speed);
                Time_t = 0.0f;
            }
        }
    }
    public static float Get_Speed()
    {
        return Speed;
    }
    private void Start()
    {
        Pos = transform.localPosition;
        Pos.y = (Speed - 5) * (1.0f / 15.0f) - 0.5f;
        transform.localPosition = Pos;
        Camera_Object = Camera.main.gameObject;
        Tolls = Camera_Object.transform.Find("Pointer").transform.Find("tools").gameObject;
    }
    public static bool Get_Auto()
    {
        return Auto;
    }
    public void Set_Auto_Mode(bool a)
    {
        Auto = a;
    }
    public void SPEED_EVENT()
    {
        Debug.Log("EVENT COLL");
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MousePos = transform.parent.transform.InverseTransformPoint(MousePos);
        MousePos.z = Pos.z;
        MousePos.x = 0.0f;
        if (-0.5f < MousePos.y && 0.5f > MousePos.y)
        {
            transform.localPosition = MousePos;
        }
        else
        {
            if (-0.5f >= MousePos.y)
            {
                MousePos.y = -0.5f;
            }
            else
            {
                MousePos.y = 0.5f;
            }
            transform.localPosition = MousePos;
        }
        Pos = transform.localPosition;
        Speed = (float)Math.Round(15.0f * (transform.localPosition.y + 0.5f) + 5.0f, MidpointRounding.AwayFromZero);
        Pos.y = (Speed - 5) * (1.0f / 15.0f) - 0.5f;
        transform.localPosition = Pos;
    }
}
