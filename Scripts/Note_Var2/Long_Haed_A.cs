using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Long_Haed_A : MonoBehaviour
{
    public float n;
    float nn;
    Vector3 defaultScale;
    private void Awake()
    {
        defaultScale = transform.lossyScale;
    }
    void Update()
    {

        Vector3 lossScale = transform.lossyScale;
        Vector3 localScale = transform.lossyScale;
        transform.localScale = new Vector3(
            transform.localScale.x / transform.lossyScale.x * defaultScale.x,
            transform.localScale.y / transform.lossyScale.y * defaultScale.y,
            transform.localScale.z / transform.lossyScale.z * defaultScale.z);
        var _spriteRenderer = transform.parent.GetComponent<SpriteRenderer>();
        var _m = _spriteRenderer.localToWorldMatrix;
        var _sprite = _spriteRenderer.sprite;
        var _halfY = _sprite.bounds.extents.y;
        var _vec = new Vector3();
        if (name == "head")
        {
            nn = -0.09f;
            _vec = new Vector3(0f, _halfY, 0f);
        }
        else
        {
            nn = 0.09f;
            _vec = new Vector3(0f, -_halfY, 0f);
        }
        var _pos = _m.MultiplyPoint3x4(_vec);
        transform.position = new Vector3(
            transform.position.x,
            _pos.y - nn,
            transform.position.z);
    }
}