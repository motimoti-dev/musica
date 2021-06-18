using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public AudioClip Clip1;
    private AudioSource audioSource;

    bool stopped = false;
    string state_1;

    public GameObject GameObject;
    public GameObject Pause;
    public GameObject Key_d;
    public GameObject Key_f;
    public GameObject Key_g;
    public GameObject Key_h;
    public GameObject Key_j;
    public GameObject Key_k;
    public GameObject Key_l;
    public float timet;
    public float timel = 0;
    private int Endc = 0;
    private int a, b = 0, c;
    //次の秒数,ぱらめーた,
    /*
    パラメータ
    -9f music clip1 再生
    -11 endフラック
    -4f ランダムレーン
    -3,-2,-1,0,1,2,3 各レーンノーツ生成
    -12,-13,-14,-
    
         
         
    */
    private float[] Gakufu = new float[] {
        1f,-9f,//ここから音楽-3.0s
        1f,    //空ノーツ　　-1.0s re4.0s

        3f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,0.25f,
        -3f,0.25f,
        -2f,0.25f,
        -1f,0.25f,
        0f,0.25f,
        1f,0.25f,
        2f,0.25f,
        3f,0.25f,
        -3f,0.25f,
        -2f,0.25f,
        -1f,0.25f,
        0f,0.25f,
        1f,0.25f,
        2f,0.25f,
        3f,0.25f,
        -3f,0.25f,
        -2f,0.25f,
        -1f,0.25f,
        0f,0.25f,
        1f,0.25f,
        2f,0.25f,
        3f,0.25f,
        -3f,0.25f,
        -2f,0.25f,
        -1f,0.25f,
        0f,0.25f,
        1f,0.25f,
        2f,0.25f,
        3f,0.25f,
        -3f,0.25f,
        -2f,0.25f,
        -1f,0.25f,
        0f,0.25f,
        1f,0.25f,
        2f,0.25f,
        3f,0.25f,
        -3f,0.25f,
        -2f,0.25f,
        -1f,0.25f,
        0f,0.25f,
        1f,0.25f,
        2f,0.25f,
        3f,0.25f,
        2f,0.25f,
        1f,0.5f,
        -3f,0.5f,
        -2f,0.5f,
        -1f,0.5f,
        0f,0.5f,
        1f,0.5f,
        2f,0.5f,
        3f,0.5f,
        2f,0.5f,
        1f,0.75f,
        1f,0.75f,
        1f,0.75f,
        1f,0.75f,
        1f,0.75f,
        1f,0.75f,
        1f,0.75f,
        1f,0.75f,
        1f,0.75f,
        1f,0.75f,
        1f,0.75f,
        1f,0.75f,
        1f,0.75f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,0.25f,
        -3f,0.25f,
        -2f,0.25f,
        -1f,0.25f,
        0f,0.25f,
        1f,0.25f,
        2f,0.25f,
        3f,0.25f,
        2f,0.25f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        -10,-1
        
                 };
    GameObject PauseUI;

    void Start()
    {
        NewMethod();
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = Clip1;
        PauseUI = GameObject.Find("PauseUI");
        PauseUI.gameObject.SetActive(false);
    }

    private void NewMethod()
    {
        state_1 = " | | ";
    }

    void OnGUI()
    {
        // ボタンを表示する
        if (GUI.Button(new Rect(700, 20, 30, 30), state_1))
        {
            Debug.Log("Button is clicked.");
            if (stopped == false)
            {
                PauseUI.gameObject.SetActive(true);
                stopped = true;
                state_1 = " ▶ ";
                //Instantiate(PauseUI, new Vector3(0, 0, 0), transform.rotation);
                Time.timeScale = 0f;
                AudioSource source = gameObject.GetComponent<AudioSource>();
                source.Pause();
            }
            else
            {
                state_1 = " | | ";

                stopped = false;
                Time.timeScale = 1f;
                AudioSource source = gameObject.GetComponent<AudioSource>();
                source.UnPause();
                PauseUI.gameObject.SetActive(false);
            }

        }
        // ボタンを表示する
        /*if (stopped == true) {
            if (GUI.Button(new Rect(700, 60, 30, 30), state_2))
            {
                Debug.Log("I have a story to tell.\n" +
                          "Do you hear me tonight.\n" +
                          "It's things about me.\n" +
                          "I'll be waiting in bedroom.\n" +
                          "But anyway you can't come." +
                          "I get it,never mind. \n" +
                          "Now, it is starting to rain.\n" +
                          " I feel you drop tears.\n" +
                          "And my heart become heavy.\n" +
                          "What's this world ...\n");

                //   GUI.Button(new Rect(20, 20, 300, 200), "I have a story to tell.\n"+
                //                                         "Do you hear me tonight.\n"+
                //                                         "It's things about me.\n"+
                //                                         "I'll be waiting in bedroom.\n" +
                //                                         "But anyway you can't come."+
                //                                         "I get it,never mind. \n" +
                //                                         "Now, it is starting to rain.\n" +
                //                                         " I feel you drop tears.\n" +
                //                                         "And my heart become heavy.\n" + 
                //                                         "What's this world ...\n" );
                                                         
                Instantiate(Pause, new Vector3(0, 0, 0), transform.rotation);
            }
  
        }*/
    }
    void Update()
    {
        if (Input.GetKeyDown("p"))//||)
        {

            Debug.Log("Button is clicked.");
            if (stopped == false)
            {
                stopped = true;
                state_1 = " ▶ ";
                //Instantiate(PauseUI, new Vector3(0, 0, 0), transform.rotation);
                Time.timeScale = 0f;
                AudioSource source = gameObject.GetComponent<AudioSource>();
                source.Pause();
            }
            else
            {
                state_1 = " | | ";

                stopped = false;
                Time.timeScale = 1f;
                AudioSource source = gameObject.GetComponent<AudioSource>();
                source.UnPause();
            }
        }
        timel += Time.deltaTime;

    aout:
        if (timel >= timet && Endc == 0)
        {
            if (Gakufu[b] == -10)
            {
                Endc -= 1;
                goto aout;
            }
            if (Gakufu[b + 1] == -9)
            {
                audioSource.Play();
            }
            b += 2;
            timet += Gakufu[b];
            if (Gakufu[b - 1] != -11 && Gakufu[b - 1] != -9)
            {
                //if()空ノ－ツ処理
                Fanc01();
            }


        }
    }

    void Fanc01()
    {
        if (Gakufu[b - 1] == -4f)
        {
            a = Random.Range(-3, 3);
        }
        else
        {
            a = (int)(Gakufu[b - 1]); 
        }
        //(int)Gakufu[b-1]
        //a = 1;
        //Debug.Log(a);
        switch (a) {

            case -3:
                Instantiate(Key_d, new Vector3(a * 2, 5f, 0), transform.rotation);
                break;

            case -2:
                Instantiate(Key_f, new Vector3(a * 2, 5f, 0), transform.rotation);
                break;

            case -1:
                Instantiate(Key_g, new Vector3(a * 2, 5f, 0), transform.rotation);
                break;

            case 0:
                Instantiate(Key_h, new Vector3(a * 2, 5f, 0), transform.rotation);
                break;

            case 1:
                Instantiate(Key_j, new Vector3(a * 2, 5f, 0), transform.rotation);
                break;

            case 2:
                Instantiate(Key_k, new Vector3(a * 2, 5f, 0), transform.rotation);
                break;

            case 3:
                Instantiate(Key_l, new Vector3(a * 2, 5f, 0), transform.rotation);
                break;

            default: 
                break;
        }
    }
}
