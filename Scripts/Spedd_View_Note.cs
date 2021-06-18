using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spedd_View_Note : MonoBehaviour
{

    float Speed;
    public GameObject SE;
    public GameObject Effect;
    private GameObject Camera_Object, Tolls;

    private void Start()
    {
        Camera_Object = Camera.main.gameObject;
        Tolls = GameObject.Find("tools");
        transform.parent = Tolls.transform;
    }
    public void Set_S(float a)
    {
        Speed = a;
    }
    void Update()
    {
        Vector3 Pos = transform.position;
        Pos.y -= Time.deltaTime * Speed;
        transform.position = Pos;
        if (transform.position.y <= 0.0f + Camera_Object.transform.position.y)
        {
            Instantiate(Effect, new Vector3(Pos.x, Pos.y, -1f), transform.rotation);
            Instantiate(SE, new Vector3(0.0f, 0.0f, 0.0f), transform.rotation);
            Destroy(gameObject);
        }
        if (!Tolls.GetComponent<AppearingTools>().Get_State())
        {
            Destroy(gameObject);
        }
    }
}
