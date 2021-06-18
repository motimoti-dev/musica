using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Note : MonoBehaviour
{
    private float hantei_time;
    public float DownSpeed = 4.5f;
    public GameObject C_SE;
    public GameObject M_SE;
    public GameObject Effect;
    private string key;
    private GameObject Destroy_object, Effect_Object;
    private bool collider_mode = false;
    private int Lane;
    private float Shift_Times, Shift_Pace, Shift_Time_T = 0.0f, Shift_Raund, Shift_Last;
    private bool Shift = false;
    private int Shift_Direction, Shift_Count = 0, Shift_Type = 0;
    private void Start()
    {
        GetComponent<SpriteRenderer>().sortingOrder = 2;
    }
    private void Update()
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
            if (hantei_time <= Destroy_object.GetComponent<Time_time>().Return_Time())
            {
                if (Input.GetKey(key) || Input.GetKeyDown(key) || Lane_Mouse() || Lane_Touch() || Lane_Mouse_Down() || Lane_Touch_Down())
                {
                    Effect_Object.GetComponent<Effect_C>().Effect_Relay(Lane, 2);
                    Debug.Log("miss");
                    Instantiate(M_SE, new Vector3(0, 0 + Destroy_object.transform.position.y, 0), transform.rotation);
                    Destroy(gameObject);
                }
                else
                {
                    Effect_Object.GetComponent<Effect_C>().Effect_Relay(Lane, 0);
                    Debug.Log("critical");
                    GameObject temp = Instantiate(Effect, new Vector3(pos.x, -4f + Destroy_object.transform.position.y, 0), transform.rotation);
                    temp.transform.parent = Destroy_object.transform;
                    Instantiate(C_SE, new Vector3(0, 0 + Destroy_object.transform.position.y, 0), transform.rotation);
                    Destroy(this.gameObject);
                }
            }
            if (Time.timeScale == 1)
            {
                if (Input.GetKeyDown(key) || Lane_Mouse_Down() || Lane_Touch_Down())
                {
                    if (collider_mode == false)
                    {
                        float a = Destroy_object.GetComponent<Time_time>().Return_Time();
                        float sa = System.Math.Abs(a - hantei_time);
                        if (sa > 0.20f) { }
                        else if (sa <= 0.1)
                        {
                            Debug.Log("miss");
                            Effect_Object.GetComponent<Effect_C>().Effect_Relay(Lane, 2);
                            Instantiate(M_SE, new Vector3(0, 0 + Destroy_object.transform.position.y, 0), transform.rotation);
                            Destroy(gameObject);
                        }
                    }
                }
            }
        }
    }
    public void Speed_C(float s)
    {
        DownSpeed = s;
    }
    public void Collider_Mode_Set(bool a)
    {
        collider_mode = a;
    }
    public void Set_Time(float a)
    {
        hantei_time = a;
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
                Debug.Log("’è‹`ŠO‚Ì’l" + Lane);
                break;
        }
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