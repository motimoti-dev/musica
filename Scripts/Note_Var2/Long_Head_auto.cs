using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Long_Head_auto : MonoBehaviour
{
    private int mode = 0, Lane;
    public float DownSpeed = 4.5f;
    private float hantei_time;
    public GameObject effect;
    public GameObject SE;
    private GameObject Destroy_object, Effect_Object, Effect_Wall;
    private float Shift_Times, Shift_Pace, Shift_Time_T = 0.0f, Shift_Raund, Shift_Last;
    private bool Shift = false;
    private int Shift_Direction, Shift_Count = 0, Shift_Type = 0;
    private void Start()
    {
        transform.Find("center").GetComponent<SpriteRenderer>().sortingOrder = 2;
    }
    private void Update()
    {
        if (transform.parent.GetComponent<Event_F_C>().Get_F())
        {
            Transform transform = this.transform;
            Vector3 pos = transform.position;
            if (mode == 0)
            {
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
                if (hantei_time <= Destroy_object.GetComponent<Time_time>().Return_Time())
                {
                    Effect_Object.GetComponent<Effect_C>().Effect_Relay(Lane, 0);
                    GameObject temp = Instantiate(effect, new Vector3(pos.x, -4f + Destroy_object.transform.position.y, 0), transform.rotation);
                    temp.transform.parent = Destroy_object.transform;
                    Instantiate(SE, new Vector3(0, 0 + Destroy_object.transform.position.y, 0), transform.rotation);
                    Debug.Log("critical");
                    Effect_Wall.GetComponent<EffectC>().Effect_Set(Lane);
                    mode = 1;
                    pos.y = -4.0f + Destroy_object.transform.position.y;
                    transform.position = pos;
                }
            }
            else if (mode == 1)
            {
                Vector3 size = transform.localScale;
                size.y += DownSpeed * Time.deltaTime * (20.0f / 3.0f);
                transform.localScale = size;
                Effect_Wall.GetComponent<EffectC>().Effect_Set(Lane);
                if (size.y >= 0)
                {
                    Effect_Object.GetComponent<Effect_C>().Effect_Relay(Lane, 0);
                    Instantiate(effect, new Vector3(pos.x, -4f + Destroy_object.transform.position.y, 0), transform.rotation);
                    Instantiate(SE, new Vector3(0, 0 + Destroy_object.transform.position.y, 0), transform.rotation);
                    Debug.Log("critical");
                    Destroy(this.gameObject);
                }
            }
        }
    }
    public void Set_Shift(float Times, float Pace, int Direction, float Raund, float last, int type)
    {
        Shift_Last = last;
        Shift = true;
        Shift_Times = Times;
        Shift_Raund = Raund;
        Shift_Pace = Pace;
        Shift_Direction = Direction;
        Shift_Type = type;
    }
    public void Speed_C(float s)
    {
        DownSpeed = s;
    }
    public void Set_Time(Vector2 a)
    {
        hantei_time = a.x;
        transform.Find("center").transform.Find("end").GetComponent<Long_End>().enabled = false;

    }
    public void Set_Lane(int lane, GameObject camera, GameObject eff, GameObject wall)
    {
        Destroy_object = camera;
        Effect_Object = eff;
        Effect_Wall = wall;
        Lane = lane;
    }
}
