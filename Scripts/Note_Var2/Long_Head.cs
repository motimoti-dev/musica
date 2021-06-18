using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Long_Head : MonoBehaviour
{
    private int mode = 0, Lane;
    public float DownSpeed = 4.5f;
    private float Delay_Time = 0.25f, coordinate, hantei_time, time_T = 0;
    public GameObject C_SE;
    public GameObject H_SE;
    public GameObject M_SE;
    public GameObject N_SE;
    public GameObject effect;
    private Vector3 worldPos;
    private string key;
    private GameObject Destroy_object, Effect_Object;
    private Vector3 mark;
    private bool collider_mode = false, F = false;
    private float Val;
    private float Shift_Times, Shift_Pace, Shift_Time_T = 0.0f, Shift_Raund, Shift_Last;
    private bool Shift = false;
    private int Shift_Direction, Shift_Count = 0, Shift_Type = 0;
    private void Start()
    {
        transform.Find("center").GetComponent<SpriteRenderer>().sortingOrder = 2;
        mark = this.transform.localScale;
        mark = transform.localScale;
    }
    private void Update()
    {
        if (transform.parent.GetComponent<Event_F_C>().Get_F())
        {
            Transform transform = this.transform;
            Vector3 pos = transform.position;
            if (hantei_time <= Destroy_object.GetComponent<Time_time>().Return_Time())
            {
                mark.y += (20.0f / 3.0f) * DownSpeed * Time.deltaTime;
                if (!F)
                {
                    F = true;
                    Instantiate(N_SE, new Vector3(0, 0 + Destroy_object.transform.position.y, 0), transform.rotation);
                }
            }
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
                if (Time.timeScale == 1)
                {
                    if (Input.GetKeyDown(key) || Lane_Mouse_Down() || Lane_Touch_Down())
                    {
                        if (collider_mode == false)
                        {
                            float a = Destroy_object.GetComponent<Time_time>().Return_Time();
                            float sa = System.Math.Abs(a - hantei_time);
                            Debug.Log(sa + sa);
                            if (sa > 0.20f) { }
                            else if (sa <= 0.05f)
                            {
                                Effect_Object.GetComponent<Effect_C>().Effect_Relay(Lane, 0);
                                Debug.Log("critical");
                                GameObject temp = Instantiate(effect, new Vector3(pos.x, -4f + Destroy_object.transform.position.y, 0), transform.rotation);
                                temp.transform.parent = Destroy_object.transform;
                                Instantiate(C_SE, new Vector3(0, 0 + Destroy_object.transform.position.y, 0), transform.rotation);
                                mode = 1;
                            }
                            else if (sa <= 0.1f)
                            {
                                Effect_Object.GetComponent<Effect_C>().Effect_Relay(Lane, 1);
                                Debug.Log("hit");
                                GameObject temp = Instantiate(effect, new Vector3(pos.x, -4f + Destroy_object.transform.position.y, 0), transform.rotation);
                                temp.transform.parent = Destroy_object.transform;

                                Instantiate(H_SE, new Vector3(0, 0 + Destroy_object.transform.position.y, 0), transform.rotation);

                                mode = 1;
                            }
                            else
                            {
                                Effect_Object.GetComponent<Effect_C>().Effect_Relay(Lane, 2);
                                Debug.Log("miss");

                                Instantiate(M_SE, new Vector3(0, 0 + Destroy_object.transform.position.y, 0), transform.rotation);

                                mode = 1;
                            }
                        }
                    }
                }
            }
            else if (mode == 1)
            {
                if (Input.GetKey(key) || Lane_Mouse() || Lane_Touch())
                {
                    pos.y = -4.0f + Destroy_object.transform.position.y;
                    transform.localScale = mark;
                    transform.position = pos;
                    if (transform.localScale.y >= DownSpeed * -0.05f)
                    {
                        Effect_Object.GetComponent<Effect_C>().Effect_Relay(Lane, 0);
                        Instantiate(C_SE, new Vector3(0, 0 + Destroy_object.transform.position.y, 0), transform.rotation);
                        Debug.Log("critical");
                        Destroy(gameObject);
                    }
                }
                else
                {
                    if (transform.localScale.y >= -DownSpeed * (20.0f / 3.0f) * 0.05f)
                    {
                        Effect_Object.GetComponent<Effect_C>().Effect_Relay(Lane, 0);
                        Instantiate(C_SE, new Vector3(0, 0 + Destroy_object.transform.position.y, 0), transform.rotation);
                        Debug.Log("critical");
                        Destroy(gameObject);
                    }
                    else if (transform.localScale.y <= -DownSpeed * (20.0f / 3.0f) * 0.1f && transform.localScale.y > -DownSpeed * (20.0f / 3.0f) * 0.2f)
                    {
                        Effect_Object.GetComponent<Effect_C>().Effect_Relay(Lane, 1);
                        Instantiate(H_SE, new Vector3(0, 0 + Destroy_object.transform.position.y, 0), transform.rotation);
                        Debug.Log("hit");
                        Destroy(gameObject);
                    }
                    else
                    {
                        mode = 2;
                        time_T = 0;
                    }
                }
            }
            else if (mode == 2)
            {
                if (Delay_Time > time_T)
                {
                    time_T += Time.deltaTime;
                    if (Input.GetKeyDown(key) || Lane_Mouse_Down() || Lane_Touch_Down())
                    {
                        mode = 1;
                        time_T = 0.0f;
                    }
                }
                else
                {
                    Effect_Object.GetComponent<Effect_C>().Effect_Relay(Lane, 2);
                    mode = 3;
                    Debug.Log("miss");
                    Instantiate(M_SE, new Vector3(0, 0 + Destroy_object.transform.position.y, 0), transform.rotation);
                }
            }
            else
            {
                pos.y -= DownSpeed * Time.deltaTime;
                transform.position = pos;
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
        transform.Find("center").transform.Find("end").GetComponent<Long_End>().Speed_Set(DownSpeed);
    }
    public void Set_Time(Vector2 a)
    {
        hantei_time = a.x;
        transform.Find("center").transform.Find("end").GetComponent<Long_End>().Set_Time(a.x + a.y);
    }
    public void Collider_Mode_Set(bool a)
    {
        collider_mode = a;
    }
    public int Return_Mode()
    {
        return mode;
    }
    public void Set_Lane(int lane, GameObject camera, GameObject eff)
    {
        Destroy_object = camera;
        Effect_Object = eff;
        Lane = lane;
        switch (Lane)
        {
            case 0:
                key = "d";
                break;
            case 1:
                key = "f";
                break;
            case 2:
                key = "g";
                break;
            case 3:
                key = "h";
                break;
            case 4:
                key = "j";
                break;
            case 5:
                key = "k";
                break;
            case 6:
                key = "l";
                break;
            default:
                Debug.Log("例外値の継承" + Lane);
                break;
        }
        transform.Find("center").transform.Find("end").GetComponent<Long_End>().Set_Lane(Lane, Destroy_object, Effect_Object);
    }
    private bool Lane_Touch()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
                if (Input.touches[i].phase == TouchPhase.Moved || Input.touches[i].phase == TouchPhase.Stationary)
                {
                    if (-7.0f + 2.0f * Lane <= worldPos.x && -5.0f + 2.0f * Lane >= worldPos.x)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        else
        {
            return false;
        }
    }
    private bool Lane_Mouse()
    {
        if (Application.platform != RuntimePlatform.IPhonePlayer && Application.platform != RuntimePlatform.Android)
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (-7.0f + 2.0f * Lane <= worldPos.x && -5.0f + 2.0f * Lane >= worldPos.x)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    private bool Lane_Touch_Down()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
                if (Input.touches[i].phase == TouchPhase.Began)
                {
                    if (-7.0f + 2.0f * Lane <= worldPos.x && -5.0f + 2.0f * Lane >= worldPos.x)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        else
        {
            return false;
        }
    }
    private bool Lane_Mouse_Down()
    {
        if (Application.platform != RuntimePlatform.IPhonePlayer && Application.platform != RuntimePlatform.Android)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (-7.0f + 2.0f * Lane <= worldPos.x && -5.0f + 2.0f * Lane >= worldPos.x)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}