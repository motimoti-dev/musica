using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectC : MonoBehaviour
{
    public GameObject walls;
    private Vector3 CameraPos;
    private void Start()
    {
        CameraPos = Camera.main.gameObject.transform.position;
    }
    void Update()
    {
        if (Time.timeScale == 1) {
            if (!Auto_Mode_Set.Get_Auto())
            {
                Touch_Pos_Effect();
                Mouse_Pos_Effect();
                if (Input.GetKey("d"))
                {

                    Instantiate(walls, new Vector3(-6, 1 + CameraPos.y, 0), transform.rotation);

                }
                if (Input.GetKey("f"))
                {

                    Instantiate(walls, new Vector3(-4, 1 + CameraPos.y, 0), transform.rotation);

                }
                if (Input.GetKey("g"))
                {

                    Instantiate(walls, new Vector3(-2, 1 + CameraPos.y, 0), transform.rotation);

                }
                if (Input.GetKey("h"))
                {

                    Instantiate(walls, new Vector3(0, 1 + CameraPos.y, 0), transform.rotation);

                }
                if (Input.GetKey("j"))
                {

                    Instantiate(walls, new Vector3(2, 1 + CameraPos.y, 0), transform.rotation);

                }
                if (Input.GetKey("k"))
                {

                    Instantiate(walls, new Vector3(4, 1 + CameraPos.y, 0), transform.rotation);

                }
                if (Input.GetKey("l"))
                {

                    Instantiate(walls, new Vector3(6, 1 + CameraPos.y, 0), transform.rotation);

                }
            }
        }
    }
    private void Touch_Pos_Effect()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Vector3 wpos = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
                if (wpos.x > -7.0f && wpos.x < -5.0f)
                {
                    Instantiate(walls, new Vector3(-6, 1 + CameraPos.y, 0), transform.rotation);
                }
                else if (wpos.x > -5.0f && wpos.x < -3.0f)
                {
                    Instantiate(walls, new Vector3(-4, 1 + CameraPos.y, 0), transform.rotation);
                }
                else if (wpos.x > -3.0f && wpos.x < -1.0f)
                {
                    Instantiate(walls, new Vector3(-2, 1 + CameraPos.y, 0), transform.rotation);
                }
                else if (wpos.x > -1.0f && wpos.x < 1.0f)
                {
                    Instantiate(walls, new Vector3(0, 1 + CameraPos.y, 0), transform.rotation);
                }
                else if (wpos.x > 1.0f && wpos.x < 3.0f)
                {
                    Instantiate(walls, new Vector3(2, 1 + CameraPos.y, 0), transform.rotation);
                }
                else if (wpos.x > 3.0f && wpos.x < 5.0f)
                {
                    Instantiate(walls, new Vector3(4, 1 + CameraPos.y, 0), transform.rotation);
                }
                else if (wpos.x > 5.0f && wpos.x < 7.0f)
                {
                    Instantiate(walls, new Vector3(6, 1 + CameraPos.y, 0), transform.rotation);
                }
            }
        }
    }
    private void Mouse_Pos_Effect()
    {
        if (Application.platform != RuntimePlatform.IPhonePlayer && Application.platform != RuntimePlatform.Android)
        {
            Vector3 wpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (wpos.x > -7.0f && wpos.x < -5.0f)
            {
                Instantiate(walls, new Vector3(-6, 1 + CameraPos.y, 0), transform.rotation);
            }
            else if (wpos.x > -5.0f && wpos.x < -3.0f)
            {
                Instantiate(walls, new Vector3(-4, 1 + CameraPos.y, 0), transform.rotation);
            }
            else if (wpos.x > -3.0f && wpos.x < -1.0f)
            {
                Instantiate(walls, new Vector3(-2, 1 + CameraPos.y, 0), transform.rotation);
            }
            else if (wpos.x > -1.0f && wpos.x < 1.0f)
            {
                Instantiate(walls, new Vector3(0, 1 + CameraPos.y, 0), transform.rotation);
            }
            else if (wpos.x > 1.0f && wpos.x < 3.0f)
            {
                Instantiate(walls, new Vector3(2, 1 + CameraPos.y, 0), transform.rotation);
            }
            else if (wpos.x > 3.0f && wpos.x < 5.0f)
            {
                Instantiate(walls, new Vector3(4, 1 + CameraPos.y, 0), transform.rotation);
            }
            else if (wpos.x > 5.0f && wpos.x < 7.0f)
            {
                Instantiate(walls, new Vector3(6, 1 + CameraPos.y, 0), transform.rotation);
            }
        }
    }
    public void Effect_Set(int Lane)
    {
        if (Lane == 0)
        {
            Instantiate(walls, new Vector3(-6, 1 + CameraPos.y, 0), transform.rotation);
        }
        else if (Lane == 1)
        {
            Instantiate(walls, new Vector3(-4, 1 + CameraPos.y, 0), transform.rotation);
        }
        else if (Lane == 2)
        {
            Instantiate(walls, new Vector3(-2, 1 + CameraPos.y, 0), transform.rotation);
        }
        else if (Lane == 3)
        {
            Instantiate(walls, new Vector3(0, 1 + CameraPos.y, 0), transform.rotation);
        }
        else if (Lane == 4)
        {
            Instantiate(walls, new Vector3(2, 1 + CameraPos.y, 0), transform.rotation);
        }
        else if (Lane == 5)
        {
            Instantiate(walls, new Vector3(4, 1 + CameraPos.y, 0), transform.rotation);
        }
        else if (Lane == 6)
        {
            Instantiate(walls, new Vector3(6, 1 + CameraPos.y, 0), transform.rotation);
        }
    }
}