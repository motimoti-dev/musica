using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownC : MonoBehaviour
{
    float coordinate;
    //判定
    float hantei;
    public float DownSpeed = 4.5f;
    public GameObject miss;
    public GameObject hit;
    public GameObject critical;
    public GameObject faster;
    //GameObject Score;
    /*	if(Input.GetKey("a")) {
    Debug.Log("A-String");
	}
	if(Input.GetKey(KeyCode.A)) {
		Debug.Log("A-KeyCode-");
	}*/
    void Update()
    {
        //取得
        Transform transform = this.transform;
        Vector3 pos = transform.position;
        pos.y -= 4.5f * Time.deltaTime;    // x座標へ0.01加算
        coordinate = pos.y;

        transform.position = pos;  // 座標を設定
        //-4.5で消す
        if (pos.y < -4.5)
        {
            Destroy(this.gameObject);
            //Debug.Log("too late for tap"+Time.time);
            Instantiate(miss, new Vector3(9, 9, 0), transform.rotation);
        }

        if (Input.GetKey("a"))
        {
            if (coordinate <= -1f && coordinate > -3.0f)
            {
                Instantiate(faster, new Vector3(9, 9, 0), transform.rotation);
                Debug.Log("none");

            }
            else if (coordinate <= -3.0f && coordinate > -3.5f)
            {

                Debug.Log("miss");
                Instantiate(miss, new Vector3(9, 9, 0), transform.rotation);
                Destroy(this.gameObject);

            }
            else if (coordinate <= -3.5f && coordinate > -3.8f)
            {
                Debug.Log("hit");
                Instantiate(hit, new Vector3(9, 9, 0), transform.rotation);
                Destroy(this.gameObject);
            }
            else if (coordinate <= -3.8f && coordinate > -4.2f)
            {
                Debug.Log("critical");
                Instantiate(critical, new Vector3(9, 9, 0), transform.rotation);
                Destroy(this.gameObject);

            }
            else if (coordinate <= -4.2f && coordinate > -4.5f)
            {
                Debug.Log("hit");
                Instantiate(hit, new Vector3(9, 9, 0), transform.rotation);
                Destroy(this.gameObject);

            }

        }
    }
    void OnMouseDown() {

        if(coordinate <= -1f && coordinate > -3.0f)
        {
            Instantiate(faster, new Vector3(9, 9, 0), transform.rotation);
            Debug.Log("none");
        
        }else if (coordinate <= -3.0f && coordinate > -3.5f)
        {

            Debug.Log("miss");
            Instantiate(miss, new Vector3(9, 9, 0), transform.rotation);
            Destroy(this.gameObject);

        }
        else if (coordinate <= -3.5f && coordinate > -3.8f)
        {
            Debug.Log("hit");
            Instantiate(hit, new Vector3(9, 9, 0), transform.rotation);
            Destroy(this.gameObject);
        }
        else if (coordinate <= -3.8f && coordinate > -4.2f)
        {
            Debug.Log("critical");
            Instantiate(critical, new Vector3(9, 9, 0), transform.rotation);
            Destroy(this.gameObject);

        }
        else if (coordinate <= -4.2f && coordinate > -4.5f)
        {
            Debug.Log("hit");
            Instantiate(hit, new Vector3(9, 9, 0), transform.rotation);
            Destroy(this.gameObject);

        }
        

    }
}
