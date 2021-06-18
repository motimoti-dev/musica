using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_center : MonoBehaviour {

    float pos_x;
    void Start()
    {
        pos_x = this.transform.position.x;
        //Transform transform = this.gameObject.GetComponent<Transform>();
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

        this.transform.Rotate(new Vector3(2, 4, 0.7f));
        this.transform.Rotate(new Vector3(2, 4, 0.7f));
    }
}
