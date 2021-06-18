using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JBorderC : MonoBehaviour {
    //ボーダー色をRGB(255,255,255,0)に変更
    [SerializeField]
    GameObject Boader;
    //色が変わる(一周する)スパン
    public float duration = 1.5f;

    void Update()
    {
        float phi = Time.time / duration * 2 * Mathf.PI;
        //振幅
        float amplitude = Mathf.Cos(phi) * 0.5f + 0.5f;

        Boader.GetComponent<Renderer>().material.color = Color.HSVToRGB(amplitude, 1, 1);
    }
    private void Start()
    {
        if (Boader == null)
        {
            Boader = gameObject;
        }
    }
}
