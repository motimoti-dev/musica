using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Cube_Easing2 : MonoBehaviour {

    public float Time_now = 0;
    public int flac, flac1 = 0;
    float pos_x,pos_y;
    void Start()
    {
        pos_x = this.transform.position.x;
        pos_y = this.transform.position.y;
        //gameObject取得 

        //今の色コンソールに出力
        Debug.Log(this.GetComponent<Renderer>().material.color);
        this.GetComponent<Renderer>().material.color = new Color(25, 25, 255, 1);

    }

    public void pastel_green()
    {

        this.GetComponent<Renderer>().material.color = new Color(25, 255, 25, 1);

    }

    public void turquoise()
    {
        this.GetComponent<Renderer>().material.color = new Color(25, 25, 255, 1);
    }

    public void black()
    {

        this.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1);

    }

    public void pink()
    {

        this.GetComponent<Renderer>().material.color = new Color(255, 25, 25, 1);

    }

    void Update()
    {

        Time_now += Time.deltaTime;
        if (Time_now >= 0.25 && flac == -1)
        {

            this.GetComponent<Transform>().DOMoveY(1.5f+pos_y, 0.249f)
            .SetEase(Ease.Linear);

            flac = 0;
        }
        if (Time_now >= 0.5 && flac == 0)
        {
            this.GetComponent<Transform>().DOMoveX(-3f + pos_x, 0.495f)
            .SetEase(Ease.Linear);
            this.GetComponent<Transform>().DOMoveY(pos_y, 0.245f)
            .SetEase(Ease.Linear);
            flac = 1;
        }
        if (Time_now >= 0.75 && flac == 1)
        {
            
            this.GetComponent<Transform>().DOMoveY(-1.5f +pos_y, 0.245f)
            .SetEase(Ease.Linear);
            flac = 2;
        }
        if (Time_now >= 1 && flac == 2)
        {
            this.GetComponent<Transform>().DOMoveX( pos_x, 0.495f)
            .SetEase(Ease.Linear);
            this.GetComponent<Transform>().DOMoveY(pos_y, 0.245f)
            .SetEase(Ease.Linear);

            flac = 3;
        }
        if (Time_now >= 1.25 && flac == 3)
        {
            
            this.GetComponent<Transform>().DOMoveY(1.5f+pos_y, 0.245f)
            .SetEase(Ease.Linear);

            flac = 4;
        }
        if (Time_now >= 1.5f && flac == 4)
        {
            this.GetComponent<Transform>().DOMoveX(3f + pos_x, 0.495f)
            .SetEase(Ease.Linear);
            this.GetComponent<Transform>().DOMoveY(pos_y, 0.245f)
            .SetEase(Ease.Linear);

            flac = 5;
        }
        if (Time_now >= 1.75 && flac == 5)
        {
            
            this.GetComponent<Transform>().DOMoveY(-1.5f +pos_y, 0.249f)
            .SetEase(Ease.Linear);
            
            flac = 6;
        }
        if (Time_now >= 2f && flac == 6)
        {
            this.GetComponent<Transform>().DOMoveX( pos_x, 0.495f)
            .SetEase(Ease.Linear);
            this.GetComponent<Transform>().DOMoveY( pos_y, 0.245f)
            .SetEase(Ease.Linear);

            Time_now = 0;
            flac = -1;
        }
        this.transform.Rotate(new Vector3(2, 4, 0.7f));


    }
}
