using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Swipe : MonoBehaviour
{
    //よ
    [Header("可動制限上下のみの時1")] [Range(0, 1)] public int state;
    [Header("上の可動制限")] [Range(0, 20)] public int Limit_UP;
    [Header("下の可動制限")] [Range(0, -20)] public int Limit_DOWN;
    //左右の制限　上下の制限
    [Header("左の可動制限")] [Range(0, -15)] public int Limit_LEFT;
    [Header("右の可動制限")] [Range(0, 15)] public int Limit_RIGHT;
    //上下の現在位置
    public static int Lane = 0;
    public static int queue = 0;
    //お寿司おごってね♡
    private GameObject Pointer, Map, Tools;
    public float Mouse_x, Mouse_y;
    //スワイプが可能か調べる
    public int flac;
    private bool Open = false;
    private float Delay, Time_t;
    public static string Scene_Name = null;
    private int i = 0;

    private void Start()
    {
        Pointer = Camera.main.gameObject;
        Map = Pointer.transform.Find("Load_Map").gameObject;
        Tools = Pointer.transform.Find("Pointer").transform.Find("tools").gameObject;
        Delay = Time_t = 1.0f;
        Scene_Name = SceneManager.GetActiveScene().name;
    }

    void Update()
    {

        Vector3 screenPos = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        Vector3 CameraPos = Pointer.transform.position;


        if (Pointer.transform.position.x == 0)
        {

        }
        if (Input.GetMouseButtonDown(0))
        {

            Mouse_x = worldPos.x;
            Mouse_y = worldPos.y;
            //アンパンマン
        }
        if (Time_t >= Delay)
            {
            if (Input.GetMouseButtonUp(0))
            {
                if (i == 1)
                {
                    Open = !Open;
                    i = 0;
                }
                if ((worldPos.x > Mouse_x) && (Mouse_x < -7.0f + Pointer.transform.position.x) && !Open)
                {
                    Debug.Log("サイドツール展開");
                    Tools.GetComponent<AppearingTools>().Open();
                    i++;
                }
                else if ((worldPos.x < Mouse_x) && (Mouse_x > -3.0f + Pointer.transform.position.x) && Open)
                {
                    Debug.Log("サイドツール収納");
                    Tools.GetComponent<AppearingTools>().Close();
                    i++;
                    Time_t = 2.5f;
                }
                else
                {
                    //イージング処理　スワイプ等速Linear 
                    if ((worldPos.x > Mouse_x) && ((worldPos.x - Mouse_x) > 4f) && i == 0 && state == 0 && Limit_LEFT < Lane && !Open)
                    {
                        Time_t = 0.0f;
                        //左スワイプ
                        Pointer.GetComponent<Transform>().DOMoveX(Pointer.transform.position.x - 18, 0.5f)
                        .SetEase(Ease.InExpo);
                        //即移動の場合
                        //Pointer.transform.position = new Vector3(Pointer.transform.position.x - 20, Pointer.transform.position.y, -10);
                        if (SceneManager.GetActiveScene().name == "advance")
                        {
                            Map.GetComponent<Load_Map_advance>().Swipe_Right();
                        }else {
                            Map.GetComponent<Load_Map>().Swipe_Right();
                        }

                        Lane--;
                    }
                    if ((worldPos.x < Mouse_x) && ((Mouse_x - worldPos.x) > 4.0f) && state == 0 && Limit_RIGHT > Lane && !Open)
                    {
                        Time_t = 0.0f;
                        //右スワイプ
                        Pointer.GetComponent<Transform>().DOMoveX(Pointer.transform.position.x + 18, 0.5f)
                        .SetEase(Ease.InExpo);
                        //Pointer.transform.position = new Vector3(Pointer.transform.position.x + 20, Pointer.transform.position.y, -10);
                        if (SceneManager.GetActiveScene().name == "advance")
                        {
                            Map.GetComponent<Load_Map_advance>().Swipe_Left();
                        }else {
                            Map.GetComponent<Load_Map>().Swipe_Left();
                        }
                        Lane++;
                    }
                    if ((worldPos.y > Mouse_y) && ((worldPos.y - Mouse_y) > 2.25f) && Limit_DOWN < queue && !Open)
                    {
                        Time_t = 0.0f;
                        //下スワイプ
                        Pointer.GetComponent<Transform>().DOMoveY(Pointer.transform.position.y - 10, 0.3f)
                        .SetEase(Ease.InExpo);
                        //Pointer.transform.position = new Vector3(Pointer.transform.position.x, Pointer.transform.position.y - 10, -10);
                        if (SceneManager.GetActiveScene().name == "advance")
                        {
                            Map.GetComponent<Load_Map_advance>().Swipe_Down();
                        }
                        else
                        {
                            Map.GetComponent<Load_Map>().Swipe_Down();
                        }
                        queue--;
                    }
                    if ((worldPos.y < Mouse_y) && ((Mouse_y - worldPos.y) > 2.25f) && Limit_UP > queue && !Open)
                    {
                        Time_t = 0.0f;
                        //上スワイプ
                        Pointer.GetComponent<Transform>().DOMoveY(Pointer.transform.position.y + 10, 0.3f)
                        .SetEase(Ease.InExpo);
                        //Pointer.transform.position = new Vector3(Pointer.transform.position.x, Pointer.transform.position.y + 10, -10);
                        if (SceneManager.GetActiveScene().name == "advance")
                        {
                            Map.GetComponent<Load_Map_advance>().Swipe_Up();
                        }
                        else
                        {
                            Map.GetComponent<Load_Map>().Swipe_Up();
                        }
                        queue++;
                    }
                }
            }
        }
        else
            {
                Time_t += Time.deltaTime;
            }

        flac = 0;
        if (Input.GetKeyDown("d") && !Open && flac == 0)
        {
            Open = true;
            Debug.Log("サイドツール展開");
            Tools.GetComponent<AppearingTools>().Open();
            flac++;
        }
        if (Input.GetKeyDown("d") && Open && flac == 0)
        {
            Open = false;
            Debug.Log("サイドツール収納");
            Tools.GetComponent<AppearingTools>().Close();
            flac++;
        }
        if (Time_t >= Delay)
        {
            if (Input.GetKeyDown("k") && !Open && Limit_UP > queue)
            {
                Time_t = 0.0f;
                //上スワイプ
                Pointer.GetComponent<Transform>().DOMoveY(Pointer.transform.position.y + 10, 0.3f)
                .SetEase(Ease.InExpo);
                //Pointer.transform.position = new Vector3(Pointer.transform.position.x, Pointer.transform.position.y + 10, -10);
                Map.GetComponent<Load_Map>().Swipe_Up();
                queue++;
            }
            if (Input.GetKeyDown("l") && !Open && Limit_DOWN < queue)
            {
                Time_t = 0.0f;
                //下スワイプ
                Pointer.GetComponent<Transform>().DOMoveY(Pointer.transform.position.y - 10, 0.3f)
                .SetEase(Ease.InExpo);
                //Pointer.transform.position = new Vector3(Pointer.transform.position.x, Pointer.transform.position.y - 10, -10);
                Map.GetComponent<Load_Map>().Swipe_Down();
                queue--;
            }
            if (Input.GetKeyDown("g") && !Open)
            {
                if (state == 0 && Limit_RIGHT > Lane)
                {
                    if (SceneManager.GetActiveScene().name == "selecter")
                    {
                        Time_t = 0.0f;
                        //右スワイプ
                        Pointer.GetComponent<Transform>().DOMoveX(Pointer.transform.position.x + 18, 0.5f)
                        .SetEase(Ease.InExpo);
                        //Pointer.transform.position = new Vector3(Pointer.transform.position.x + 20, Pointer.transform.position.y, -10);
                        Map.GetComponent<Load_Map>().Swipe_Left();
                        Lane++;
                    }
                }
            }
            if (Input.GetKeyDown("f") && !Open)
            {
                if (state == 0 && Limit_LEFT < Lane)
                {
                    if (SceneManager.GetActiveScene().name == "selecter")
                    {
                        Time_t = 0.0f;
                        //左スワイプ
                        Pointer.GetComponent<Transform>().DOMoveX(Pointer.transform.position.x - 18, 0.5f)
                        .SetEase(Ease.InExpo);
                        //即移動の場合
                        //Pointer.transform.position = new Vector3(Pointer.transform.position.x - 20, Pointer.transform.position.y, -10);
                        Map.GetComponent<Load_Map>().Swipe_Right();
                        Lane--;
                    }
                }
            }
        }
        else
        {
            Time_t += Time.deltaTime;
        }
        if (Input.GetKeyDown("h") && Open)
        {
            if (SceneManager.GetActiveScene().name == "selecter")
            {
                //アドバンスへのシーン遷移
                SceneManager.LoadScene("advance");
            }
            else
            {
                SceneManager.LoadScene("selecter");
            }
        }
    }
    public static string Get_Scene_Name()
    {
        return Scene_Name;
    }
}