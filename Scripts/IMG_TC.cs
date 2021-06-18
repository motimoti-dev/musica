using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMG_TC : MonoBehaviour
{
    public static Sprite IMG;
    public static Vector3 size, pos;
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sortingOrder = -1;
        pos = transform.position;
        IMG = this.GetComponent<SpriteRenderer>().sprite;
        size = transform.localScale;
    }
    public static Sprite Return_img()
    {
        return IMG;
    }
    public static Vector3 Return_pos()
    {
        return pos;
    }
    public static Vector3 Return_size()
    {
        return size;
    }
}
