using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingC : MonoBehaviour {
    private AsyncOperation async;
    private GameObject LoadSceneUI;
    private Slider LoadSlider;
    public string music;
    private GameObject Pointer, Select_Object, Tolls_Object, Load_Map_Object;
    public float Mouse_x, Mouse_y;
    public int touch;
    int a = 0;
    bool b = false;
    void Start()
    {
        Pointer = Camera.main.gameObject;
        LoadSceneUI = Pointer.transform.Find("Canvas").transform.Find("LoadBar").gameObject;
        //この処理重い
        Load_Map_Object = Pointer.transform.Find("Load_Map").gameObject;
        Select_Object = Pointer.transform.Find("BG_Cube").gameObject;
        Tolls_Object = Pointer.transform.Find("Pointer").transform.Find("tools").gameObject;
        //わかる(分かってない上に追加するスタイル())
        LoadSlider = LoadSceneUI.transform.Find("ProcessBar").GetComponent<Slider>();
        //
        touch = 0;
        //LoadBarのSetActiveをInspector上からtrueにしないと曲&譜面が読まれません。.Hotcocoa
    }
    public void OnMouseDown()
    {
        
        touch = 1;
    }
    private void Update()
    {
        
        if (a == 0) {
            a++;
            LoadSceneUI.SetActive(false);
        }
        Vector3 screenPos = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        Vector3 CameraPos = Pointer.transform.position;
        if (Input.GetMouseButtonDown(0))
        {

            Mouse_x = worldPos.x;
            Mouse_y = worldPos.y;

        }

        if (Input.GetMouseButtonUp(0)&&touch ==1)
        {
            touch = 0;
            if (worldPos.x == Mouse_x && worldPos.y == Mouse_y)
                StartCoroutine(LoadScene());
        }
        if (Input.GetKeyDown("j"))
        {
            if (!b)
            {
                if (SceneManager.GetActiveScene().name == "selecter")
                {
                    if (Select_Object.transform.position.x == transform.position.x && Select_Object.transform.position.y == transform.position.y && !Tolls_Object.GetComponent<AppearingTools>().Get_State())
                    {
                        StartCoroutine(LoadScene());
                    }
                }
                else
                {
                    if (Pointer.transform.position.y == transform.position.y && !Tolls_Object.GetComponent<AppearingTools>().Get_State())
                    {
                        StartCoroutine(LoadScene());
                    }
                }
            }
        }
    }
    public IEnumerator LoadScene()
    {
        if (!Tolls_Object.GetComponent<AppearingTools>().Get_State())
        {
            if (!b)
            {
                b = !b;
                //Pointer.transform.position = new Vector3(1000, -1000, 0);
                LoadSceneUI.SetActive(true);
                //LoadSceneAsync にタイトル(string型)を入力すろ必要有。
                async = SceneManager.LoadSceneAsync(music);
                async.allowSceneActivation = false;

                while (async.isDone == false)
                {
                    LoadSlider.value = async.progress;
                    ///per=async.progress;
                    if (async.progress == 0.9f)
                    {
                        LoadSlider.value = 1f;
                        async.allowSceneActivation = true;
                    }
                    yield return null;//帰りたい
                }
                //
                //お主よ 大変じゃのう
                //救済措置なのじゃ
                //...そんなものはあるまい
                //
            }
        }
    }
}
