using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_time : MonoBehaviour
{
    public float time_t;
    private bool flag = false;
    void Update()
    {
        if (flag)
        {
            time_t += Time.deltaTime;
        }
    }
    public float Return_Time()
    {
        return time_t;
    }
    public void FLAG_SET(float a)
    {
        flag = true;
        time_t = -(10.0f / a);
    }
    private void Start()
    {
        flag = false;
    }
}
