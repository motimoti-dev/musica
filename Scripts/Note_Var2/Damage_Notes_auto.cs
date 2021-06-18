using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Notes_auto : MonoBehaviour {

    //もう戻らないあの頃


    //座標
    float coordinate;
    float hantei;

    public float DownSpeed = 10f;
    private GameObject Destroy_object;
    public GameObject SE;
    public GameObject critical;
    public GameObject effect;

    //たこ焼き
    private void Start()
    {
        Destroy_object = GameObject.Find("Main Camera");
    }
    public void Speed_C(float s)
    {
        DownSpeed = s;
    }
    void Update()
    {
        Transform transform = this.transform;
        Vector3 pos = transform.position;
        pos.y -= DownSpeed * Time.deltaTime;
        coordinate = pos.y;
        transform.position = pos;
        if (Time.timeScale == 1)
        {

            if (coordinate <= -4.0f + Destroy_object.transform.position.y)
            {
                Debug.Log("critical");

                Instantiate(critical, new Vector3(9, 9 + Destroy_object.transform.position.y, 0), transform.rotation);
                GameObject temp = Instantiate(effect, new Vector3(pos.x, -4f + Destroy_object.transform.position.y, 0), transform.rotation);
                temp.transform.parent = Destroy_object.transform;
                Instantiate(SE, new Vector3(0, 0 + Destroy_object.transform.position.y, 0), transform.rotation);

                Destroy(this.gameObject);

            }

        }
    }

}

