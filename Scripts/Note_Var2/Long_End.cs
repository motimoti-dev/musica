using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Long_End : MonoBehaviour
{
    private float DownSpeed;
    private Vector3 pos;
    private GameObject head_object, Destroy_object, Effect_Object;
    private int flag;
    public GameObject M_SE;
    public GameObject N_SE;
    private bool F = false;
    private float hantei_time;
    private int Lane;
    private Vector3 defaultScale = Vector3.zero;
    private void Start()
    {
        head_object = transform.parent.transform.parent.gameObject;
    }
    private void Awake()
    {
        defaultScale = transform.lossyScale;
    }
    private void Update()
    {
        Vector3 lossScale = transform.lossyScale;
        Vector3 localScale = transform.lossyScale;
        transform.localScale = new Vector3(
            transform.localScale.x / transform.lossyScale.x * defaultScale.x,
            transform.localScale.y / transform.lossyScale.y * defaultScale.y,
            transform.localScale.z / transform.lossyScale.z * defaultScale.z);
        if (hantei_time <= Destroy_object.GetComponent<Time_time>().Return_Time())
        {
            if (!F)
            {
                F = true;
                Instantiate(N_SE, new Vector3(0, 0 + Destroy_object.transform.position.y, 0), transform.rotation);
            }
        }
        if (Time.timeScale == 1)
        {
            if (hantei_time <= Destroy_object.GetComponent<Time_time>().Return_Time())
            {
                if (transform.parent.transform.parent.GetComponent<Long_Head>().Return_Mode() == 0)
                {
                    Effect_Object.GetComponent<Effect_C>().Effect_Relay(Lane, 2);
                    Debug.Log("miss");
                    Effect_Object.GetComponent<Effect_C>().Effect_Relay(Lane, 2);
                    Debug.Log("miss");
                    Instantiate(M_SE, new Vector3(0, 0 + Destroy_object.transform.position.y, 0), transform.rotation);
                    Destroy(head_object.gameObject);
                }
                else if (transform.parent.transform.parent.GetComponent<Long_Head>().Return_Mode() == 3)
                {
                    Effect_Object.GetComponent<Effect_C>().Effect_Relay(Lane, 2);
                    Debug.Log("miss");
                    Instantiate(M_SE, new Vector3(0, 0 + Destroy_object.transform.position.y, 0), transform.rotation);
                    Destroy(head_object.gameObject);
                }
            }
        }
    }
    public void Speed_Set(float a)
    {
        DownSpeed = a;
    }
    public void Set_Time(float a)
    {
        hantei_time = a;
    }
    public void Set_Lane(int a, GameObject camera, GameObject eff)
    {
        Destroy_object = camera;
        Effect_Object = eff;
        Lane = a;
    }
}