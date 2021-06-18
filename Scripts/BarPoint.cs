using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarPoint : MonoBehaviour
{
    private Vector3 MousePos;
    private int speed = 5;
    public GameObject SPEED;
    public float y = 3.3f;
    public void BarEvent()
    {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MousePos.z = -1.0f;
        if (-3.0f < MousePos.y && 7.0f > MousePos.y)
        {
            transform.position = MousePos;
        }
        else
        {
            if (-3.0f >= MousePos.y)
            {
                MousePos.x = -3.0f;
            }
            else
            {
                MousePos.x = 7.0f;
            }
            transform.position = MousePos;
        }
        speed = (int)((transform.position.x + 3.0f) / 10.0f * 20.0f);
        speed++;
    }
}