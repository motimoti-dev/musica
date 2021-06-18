using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Event : MonoBehaviour
{
    Vector3 pos;
    GameObject Play;
    int ef = 0, ID = 0, n = 0, f = 0, p;
    float time_t, speed, delay, all, a, b, c, d, space, e;
    private void Start()
    {
        Play = Camera.main.GetComponent<Object_Relay>().Get_PlayC();
        pos = this.gameObject.transform.position;
    }
    private void Update()
    {
        if (ID == 1)//Doppelganger用イベント
        {
            if (n == 0)
            {
                if (ef == 0 && f == 0)
                {
                    space = 0.4f;
                    Play.GetComponent<PlayC>().Switch_Field(2);
                    all = Play.GetComponent<PlayC>().Time_NOW_ADD(space);
                    f = 1;
                    delay = Delay_Calculation();
                    all -= delay;
                    Debug.Log("all:" + all);
                    Debug.Log("deley" + delay);
                }
                else if (ef == 0 && f == 1)
                {

                    time_t += Time.deltaTime;
                    if (time_t >= delay)
                    {
                        pos = transform.position;
                        ef_s_on(2);
                        Play.GetComponent<PlayC>().Field_Close(2);
                        f = 2;
                        b = 1;
                        time_t = 0.0f;
                        a = pos.x;
                    }
                }
                else if (ef == 1 && f == 2)
                {
                    a += 0.01f;
                    b *= -1.0f;
                    transform.position = new Vector3(a * b, pos.y, pos.z);
                    time_t += Time.deltaTime;
                    if (time_t >= all)
                    {
                        transform.position = new Vector3(0.0f, 0.0f, -10.0f);
                        ef_s_off(2);
                        Play.GetComponent<PlayC>().Field_Open(2);
                        ID = f = 0;
                        n++;
                    }
                }
            }
        }
        else if (ID == 2)//Grievous用イベント
        {
            if (n == 0)
            {
                if (ef == 0 && f == 0)
                {
                    space = 0.1f;
                    b = 3;
                    Play.GetComponent<PlayC>().Switch_Field(2);
                    all = Play.GetComponent<PlayC>().Time_NOW_ADD(space);
                    delay = Delay_Calculation();
                    all -= delay;
                    a = all / (b + 1);
                    c = a * b;
                    time_t = 0;
                    Debug.Log("all:" + all);
                    Debug.Log("delay:" + delay);
                    Debug.Log("c:" + c);
                    f = 1;
                }
                else if (ef == 0 && f == 1)
                {
                    time_t += Time.deltaTime;
                    if (time_t >= delay)
                    {
                        ef_s_on(2);
                        time_t = 0.0f;
                    }
                }
                else if (ef == 1)
                {
                    if (f == 1)
                    {
                        time_t += Time.deltaTime;
                        float y = pos.y;
                        y -= (Time.deltaTime * speed) / b;
                        pos.y = y;
                        this.gameObject.transform.position = pos;
                        if (time_t >= c)
                        {
                            f = 0;
                        }
                    }
                    else if (f == 0)
                    {
                        float y = pos.y;
                        y += Time.deltaTime * speed;
                        pos.y = y;
                        this.gameObject.transform.position = pos;
                        if (pos.y >= 0)
                        {
                            ef_s_off(2);
                            n++;
                            ID = 0;
                            y = 0;
                            pos.y = 0.0000000000f;
                            pos.y = y;
                            this.gameObject.transform.position = pos;
                        }
                    }
                }
            }
            else if (n == 1)
            {
                if (f == 0 && ef == 0)
                {
                    space = 0.25f;
                    a = 16;
                    Play.GetComponent<PlayC>().Switch_Field(1);
                    all = Play.GetComponent<PlayC>().Time_NOW_ADD(space);
                    delay = Delay_Calculation();
                    all -= delay;
                    f = 1;
                    b = all / a;
                    time_t = 0.0f;
                    d = all;
                    c = 0.9f;
                }
                else if (f == 1)
                {
                    time_t += Time.deltaTime;
                    if (time_t >= delay)
                    {
                        ef_s_on(1);
                        f = 2;

                        time_t = 0.0f;
                    }
                }
                else if (f == 2)
                {
                    time_t += Time.deltaTime;
                    pos.y += Time.deltaTime * c * speed;
                    this.transform.position = pos;
                    if (time_t >= b * 2.00f)
                    {
                        f = 3;
                        d -= time_t;
                        time_t = 0.0f;
                    }
                }
                else if (f == 3)
                {
                    time_t += Time.deltaTime;
                    pos.y -= Time.deltaTime * 1.00f * speed;
                    this.transform.position = pos;
                    if (time_t >= b * 2.00f)
                    {
                        f = 4;
                        d -= time_t;
                        time_t = 0.0f;
                    }
                }
                else if (f == 4)
                {
                    time_t += Time.deltaTime;
                    pos.y += Time.deltaTime * 2.00f * speed;
                    this.transform.position = pos;
                    if (time_t >= b)
                    {
                        f = 5;
                        d -= time_t;
                        time_t = 0.0f;
                    }
                }
                else if (f == 5)
                {
                    time_t += Time.deltaTime;
                    pos.y -= Time.deltaTime * 2.00f * speed;
                    this.transform.position = pos;
                    if (time_t >= b)
                    {
                        f = 6;
                        d -= time_t;
                        time_t = 0.0f;
                    }
                }
                else if (f == 6)
                {
                    time_t += Time.deltaTime;
                    if (time_t >= b)
                    {
                        f = 7;
                        d -= time_t;
                        time_t = 0.0f;
                    }
                }
                else if (f == 7)
                {
                    time_t += Time.deltaTime;
                    pos.y += Time.deltaTime * 2.00f * speed;
                    this.transform.position = pos;
                    if (time_t >= b)
                    {
                        f = 8;
                        d -= time_t;
                        time_t = 0.0f;
                    }
                }
                else if (f == 8)
                {
                    time_t += Time.deltaTime;
                    pos.y -= Time.deltaTime * 1.30f * speed;
                    this.transform.position = pos;
                    if (time_t >= b * 4.00f)
                    {
                        Debug.Log("pos.y:" + pos.y);
                        f = 9;
                        d -= time_t;
                        time_t = 0.0f;
                        e = System.Math.Abs(pos.y) / d / speed;
                        Debug.Log("d:" + d);
                        Debug.Log("e:" + e);
                    }
                }
                else if (f == 9)
                {
                    time_t += Time.deltaTime;
                    pos.y += Time.deltaTime * e * speed;
                    this.transform.position = pos;
                    if (time_t >= d)
                    {
                        pos.y = 0.000000000f;
                        this.transform.position = pos;
                        ef_s_off(1);
                        ID = 0;
                        f = 0;
                        n++;
                        time_t = 0.0f;
                    }
                }
            }
        }
        if (ID == 3)//馬と鹿用イベント
        {
            if (n == 0)
            {
                if (ef == 0 && f == 0)
                {
                    space = 0.4f;
                    Play.GetComponent<PlayC>().Switch_Field(2);
                    all = Play.GetComponent<PlayC>().Time_NOW_ADD(space);
                    f = 1;
                    delay = Delay_Calculation();
                    all -= delay;
                    Debug.Log("all:" + all);
                    Debug.Log("deley" + delay);
                }
                else if (ef == 0 && f == 1)
                {

                    time_t += Time.deltaTime;
                    if (time_t >= delay)
                    {
                        pos = transform.position;
                        ef_s_on(2);
                        f = 2;
                        time_t = 0.0f;
                    }
                }
                else if (ef == 1 && f == 2)
                {
                    time_t += Time.deltaTime;
                    if (time_t >= all)
                    {
                        ef_s_off(2);
                        ID = f = 0;
                        n++;
                    }
                }
            }
            else if (n == 1)
            {
                if (ef == 0 && f == 0)
                {
                    space = 0.4f;
                    Play.GetComponent<PlayC>().Switch_Field(1);
                    all = Play.GetComponent<PlayC>().Time_NOW_ADD(space);
                    f = 1;
                    delay = Delay_Calculation();
                    all -= delay;
                    Debug.Log("all:" + all);
                    Debug.Log("deley" + delay);
                }
                else if (ef == 0 && f == 1)
                {

                    time_t += Time.deltaTime;
                    if (time_t >= delay)
                    {
                        b = all * 3.0f / 4.0f;
                        pos = transform.position;
                        ef_s_on(1);
                        f = 2;
                        time_t = 0.0f;
                        a = pos.z;
                        pos.z = 0.0f;
                        transform.position = pos;
                    }
                }
                else if (ef == 1 && f == 2)
                {
                    time_t += Time.deltaTime;
                    if (time_t >= b)
                    {
                        time_t = 0.0f;
                        pos.z = a;
                        f = 3;
                        transform.position = pos;
                    }
                }
                else if (ef == 1 && f == 3)
                {
                    time_t += Time.deltaTime;
                    if (time_t >= all - b)
                    {
                        ef_s_off(1);
                        ID = f = 0;
                        n++;
                    }
                }
            }
        }
        if (ID == 4)
        {
            if (n == 0)
            {
                if (f == 0)
                {
                    time_t = 0.0f;
                    delay = Delay_Calculation();
                    f = 1;
                }
                else if (f == 1)
                {
                    time_t += Time.deltaTime;
                    if (time_t >= delay)
                    {
                        time_t = 0.0f;
                        pos = transform.position;
                        f = 2;
                    }
                }
                else if (f == 2)
                {
                    //イベント時間
                    a = 2.545f;
                    time_t += Time.deltaTime;
                    //振れ幅 * sinカーブを描く(時間 * 2π *(周期 / イベント時間))
                    pos.x = 2.0f * Mathf.Sin(time_t * 2.0f * Mathf.PI * (1.5f / a));
                    transform.position = pos;
                    if (time_t >= a)
                    {
                        pos.x = 0.0f;
                        transform.position = pos;
                        ID = f = 0;
                        n++;
                    }
                }
            }
        }
    }
    public int Checkef()
    {
        return ef;
    }
    public void SetID(int a, float s,GameObject g)
    {
        Play = g;
        ID = a;
        speed = s;
        time_t = 0.0f;
        f = 0;
    }
    void ef_s_off(int N)
    {
        ef = 0;
        Debug.Log("ef=0");
        Play.GetComponent<PlayC>().Field_Open(N);
    }
    void ef_s_on(int N)
    {
        ef = 1;
        Debug.Log("ef=1");
        Play.GetComponent<PlayC>().Field_Close(N);
    }
    private float Delay_Calculation()
    {
        return 10.0f / speed;
    }
}
