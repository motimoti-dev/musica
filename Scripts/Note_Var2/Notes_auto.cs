using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes_auto : MonoBehaviour
{

    //もう戻らないあの頃


    public float hantei_time;
    public float DownSpeed;
    int Lane;

    public GameObject SE;
    public GameObject effect;
    private GameObject Destroy_object, Effect_Object, Effect_Wall;
    private float Shift_Times, Shift_Pace, Shift_Time_T = 0.0f, Shift_Raund, Shift_Last;
    private bool Shift = false;
    private int Shift_Direction, Shift_Count = 0, Shift_Type = 0;
    //たこ焼き

    public void Speed_C(float s)
    {
        DownSpeed = s;
    }
    void Update()
    {
        if (transform.parent.GetComponent<Event_F_C>().Get_F())
        {
            Transform transform = this.transform;
            Vector3 pos = transform.position;
            pos.y -= DownSpeed * Time.deltaTime;
            if (Shift)
            {
                if (Shift_Type == 1)
                {
                    pos.x += Shift_Pace * Time.deltaTime * Shift_Direction;
                    Shift_Time_T += Time.deltaTime;
                    if (Shift_Time_T >= Shift_Raund)
                    {
                        Shift_Time_T = 0.0f;
                        Shift_Count++;
                        if (Shift_Times - 1 == Shift_Count)
                        {
                            Shift_Raund = Shift_Last;
                        }
                        if (Shift_Count == Shift_Times)
                        {
                            Shift = false;
                            pos.x = -6 + 2 * Lane;
                        }
                        else
                        {
                            Shift_Direction = -1 * Shift_Direction;
                        }
                    }
                }
                else if (Shift_Type == 2)
                {   
                    if (Shift_Count == 0)
                    {
                        Shift_Time_T += Time.deltaTime;
                        if (Shift_Time_T >= Shift_Raund)
                        {
                            Shift_Time_T = 0.0f;
                            Shift_Count++;
                        }
                    }
                    else if (Shift_Count == 1)
                    {
                        pos.x += Time.deltaTime * Shift_Direction * Shift_Pace;
                        Shift_Time_T += Time.deltaTime;
                        if (Shift_Time_T >= Shift_Last)
                        {
                            Shift = false;
                            pos.x = -6 + 2 * Lane;
                        }
                    }
                }
                else if (Shift_Type == 3)
                {
                    if (Shift_Count == 0)
                    {
                        Shift_Time_T += Time.deltaTime;
                        pos.x += Shift_Pace * Time.deltaTime * Shift_Direction;
                        if (Shift_Time_T >= Shift_Last)
                        {
                            Shift = false;
                            pos.x = -6 + 2 * Lane;
                        }
                    }
                }
            }
            transform.position = pos;
            if (Time.timeScale == 1)
            {

                if (hantei_time <= Destroy_object.GetComponent<Time_time>().Return_Time())
                {
                    Debug.Log("critical");
                    if (name != "Damage_Note")
                    {
                        Effect_Wall.GetComponent<EffectC>().Effect_Set(Lane);
                    }
                    Effect_Object.GetComponent<Effect_C>().Effect_Relay(Lane, 0);
                    GameObject temp = Instantiate(effect, new Vector3(pos.x, -4f + Destroy_object.transform.position.y, 0), transform.rotation);
                    temp.transform.parent = Destroy_object.transform;
                    Instantiate(SE, new Vector3(0, 0 + Destroy_object.transform.position.y, 0), transform.rotation);
                    Destroy(this.gameObject);

                }
            }
        }
    }
    public void Set_Shift(float Times, float Pace, int Direction,float Raund,float last,int type)
    {
        Shift_Last = last;
        Shift = true;
        Shift_Times = Times;
        Shift_Raund = Raund;
        Shift_Pace = Pace;
        Shift_Direction = Direction;
        Shift_Type = type;
    }
    public void Set_Time(float a)
    {
        hantei_time = a;
    }
    public void Set_Lane(int a, GameObject camera, GameObject eff, GameObject wall)
    {
        Destroy_object = camera;
        Effect_Object = eff;
        Effect_Wall = wall;
        Lane = a;
    }
}