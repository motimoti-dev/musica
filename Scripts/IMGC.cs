using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMGC : MonoBehaviour
{
    public Sprite sprite;
    public Vector3 pos, size;
    void Start()
    {
        sprite = IMG_TC.Return_img();
        pos = IMG_TC.Return_pos();
        size = IMG_TC.Return_size();
        GetComponent<SpriteRenderer>().sprite = sprite;
        transform.position = pos;
        transform.localScale = size;
        GetComponent<SpriteRenderer>().color = new Color32(100, 100, 100, 255);
    }
}
