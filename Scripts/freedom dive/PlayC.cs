using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Video;
public class PlayC : MonoBehaviour
{
    //text名
    string T_fumen;
    //タグ
    int flac_End, flac_Start, flac_ex;
    //現在経過時間
    public float Time_now;
    //タイムカウンタ
    public float Time_C;
    //行数指定
    int Line;
    //レーン
    int Lane;
    //楽譜配列のパラメータ部分
    int Parameter;
    //同時ノーツのチェック
    int simultaneous;
    //速度倍率
    float magnification;
    //譜面のズレ基本は0
    float plus;
    //オーディオクリップス
    private AudioSource audioSource;
    //ストップボタンの文字
    bool stopped = false;
    private GameObject PauseUI;
    //i9用です
    int a = 0;
    //ポーズ画面のUI
    public GameObject Pause;
    //各ボタン用ノ－ツだったもの
    public GameObject notes;
    public GameObject long_notes;
    public GameObject damage_notes;
    public GameObject hold_notes;
    private GameObject temp;
    //
    public float timet;
    public float SPEED = 10f;
    private float delay;
    private float delay_time = 0.0f;
    private bool delay_flag = false;
    float music_c;
    private float constant = 10.0f;
    public int EVENTID;
    public bool Player_Mode = false;
    public GameObject BGA;
    private GameObject Field, Wall_Effect;
    private GameObject Effect;
    /*
    譜面データについて 
    配列の列
    -1      曲の終わり
    0   　  曲の始まり0,曲とのずれ,0,0,0,0
    1       ノーツ
    2     　ロングノーツ 
    3       ダメージノーツ   
    4       スライドノーツ
    5       イベント
    6       ホールド
    7       同時ノーツの指定
    8     　予備
    9       時間
    1ノーツについて
    1,レーン番号,速度倍率,同時ノーツ,予備
    2
    
    private double[,] Gakufu = new double[,] {
        {0,0,0,0,0,0},
        {1,0,1,0,0,0},
        {1,1,1,0,0,0},

    };
    */
    //もう戻らないあの頃
    string state_1;
    private string[] textMessage;
    //テキストの加工前の一行を入れる変数
    private string[,] Gakufu;
    //テキストの複数列を入れる2次元は配列 

    private int rowLength;
    //テキスト内の行数を取得する変数
    public TextAsset text;
    private GameObject Event_object, Field1, Field2, Fild_Now;
    private GameObject Score_Object;

    //レーン移動挙動
    private bool Shift_Flag = false;
    private float X_Pace = 0.0f;
    private int Shift_Times = 0;
    private float Shift_Slip = 0.0f;
    private float Shift_Round_Time = 0.0f;
    private int Shift_Direction = 0;
    private float Shift_Last_Round = 0.0f;
    private int Shift_Type = 0;
    private float Shift_Timing = 0.0f;
    void Awake()
    {
        string TextLines = text.text;
        //テキスト全体をstring型で入れる変数を用意して入れる

        //Splitで一行づつを代入した1次配列を作成
        textMessage = TextLines.Split('\n');

        //行数と列数を取得
        rowLength = textMessage.Length;

        //2次配列を定義
        Gakufu = new string[rowLength, 7];
        Debug.Log(rowLength);
        for (int i = 0; i < rowLength; i++)
        {

            string[] tempWords = textMessage[i].Split(',');

            //textMessageをカンマごとに分けたものを一時的にtempWordsに代入

            for (int n = 0; n <= 5; n++)
            {
                //2次配列textWordsにカンマごとに分けたtempWordsを代入していく

                Gakufu[i, n] = tempWords[n];
                //Debug.Log(Gakufu[i, n]);

            }
        }
    }
    void Start()
    {
        Event_object = Camera.main.gameObject;
        var Relay = Event_object.GetComponent<Object_Relay>();
        Score_Object = Relay.Get_ScoreManager();
        Effect = Event_object.transform.Find("Canvas").transform.Find("Effect").gameObject;
        Field1 = Relay.Get_Note().transform.Find("F_1").gameObject;
        Field2 = Relay.Get_Note().transform.Find("F_2").gameObject;
        Fild_Now = Field1;
        PauseUI = Relay.Get_PauseUI();
        Wall_Effect = Relay.Get_Effecter();
        //Debug.Log(BGA.name);
        SPEED = Speed_View.Get_Speed();
        if (Application.platform != RuntimePlatform.WindowsEditor && Application.platform != RuntimePlatform.LinuxEditor && Application.platform != RuntimePlatform.OSXEditor || Swipe.Get_Scene_Name() != null)
        {
            Player_Mode = !Auto_Mode_Set.Get_Auto();
        }
        else if (!Player_Mode)
        {
            Auto_Mode_Set.Auto_Mode = true;
        }
        //
        Line = 0;
        Time_C = 0;
        Time_now = 0;
        flac_End = 0;
        NewMethod();
        //オーディオソースの取得
        audioSource = gameObject.GetComponent<AudioSource>();
        //ポーズUIの取得
        PauseUI.gameObject.SetActive(false);





        /*
        //テキストアセット
        TextAsset textasset = new TextAsset();
        //テキストファイルのデータを取得するインスタンスを作成
        textasset = Resources.Load("test", typeof(TextAsset)) as TextAsset;
        
        //Resourcesフォルダから対象テキストを取得
        string TextLines = textasset.text;
        */
        /*
        string TextLines = text.text;
        //テキスト全体をstring型で入れる変数を用意して入れる

        //Splitで一行づつを代入した1次配列を作成
        textMessage = TextLines.Split('\n');

        //行数と列数を取得
        rowLength = textMessage.Length;

        //2次配列を定義
        Gakufu = new string[rowLength, 7];
        Debug.Log(rowLength);
        for (int i = 0; i < rowLength; i++)
        {

            string[] tempWords = textMessage[i].Split(',');

            //textMessageをカンマごとに分けたものを一時的にtempWordsに代入

            for (int n = 0; n <= 5; n++)
            {
                //2次配列textWordsにカンマごとに分けたtempWordsを代入していく

                Gakufu[i, n] = tempWords[n];
                //Debug.Log(Gakufu[i, n]);

            }
        }
        */
        delay = constant / SPEED;
        plus = float.Parse(Gakufu[0, 1]) + 0.039f;
        if (Gakufu[0, 2] != "0")
        {
            Score_Object.GetComponent<scoreC>().Set_Sound(Gakufu[0, 2]);
        }
        if (Gakufu[0, 3] != "0")
        {
            Score_Object.GetComponent<scoreC>().Set_Sound(Gakufu[0, 3]);
        }
        for (int i = 1; i < rowLength - 1; i++)
        {
            Gakufu[i, 6] = "" + (float.Parse(Gakufu[i, 3]) - ((1.0f / float.Parse(Gakufu[i, 2]) * delay)) + delay);
        }
        for (int j = 0; j < rowLength - 2; j++)
        {
            for (int i = 1; i < rowLength - 2; i++)
            {
                if (float.Parse(Gakufu[i, 6]) > float.Parse(Gakufu[i + 1, 6]))
                {
                    for (int str_c = 0; str_c < 7; str_c++)
                    {
                        string Temp_Str = Gakufu[i, str_c];
                        Gakufu[i, str_c] = Gakufu[i + 1, str_c];
                        Gakufu[i + 1, str_c] = Temp_Str;
                    }
                }
            }
        }
        Gakufu[rowLength - 1, 6] = "0.0";
        //エンドフラグ
        flac_End = 1;
        //Updata内に置くなKs
    }

    private void NewMethod()
    {
        state_1 = " | | ";
    }
    void Update()
    {
        if (flac_End == 1)
        {
            if (Event_object.GetComponent<Test_Event>().Checkef() == 0)
            {
                Time_now += Time.deltaTime;
            }
            if (delay_flag)
            {
                delay_time += Time.deltaTime;
                if (delay_time >= delay)
                {
                    delay_flag = false;
                    Music_Play();
                }
            }
            if (Time_now >= Time_C)
            {
                if (Gakufu[Line, 6] != null && Gakufu[Line, 0] != "-1")
                {
                    for (simultaneous = 1; Gakufu[Line, 6] == Gakufu[Line + simultaneous, 6]; simultaneous++) ;
                }
                else
                {
                    simultaneous = 1;
                }
                for (int c = 0; c < simultaneous; c++)
                {
                    Parameter = int.Parse(Gakufu[Line, 0]);
                    if (Parameter != 0)
                    {
                        //Random_Shift_03();
                        //Random_Shift_02();
                        //Random_Shift_01();
                    }
                    switch (Parameter)
                    {
                        case -1:
                            //-1で終了
                            flac_End = 0;
                            break;

                        case 0:
                            //0で音楽開始
                            Event_object.GetComponent<Time_time>().FLAG_SET(SPEED);
                            delay_flag = true;
                            //Invoke("Music_Play", delay);
                            Line++;
                            Time_C = float.Parse(Gakufu[Line, 6]) + plus;
                            break;

                        case 1:

                            Note();
                            Time_C = float.Parse(Gakufu[Line, 6]) + plus;
                            break;

                        case 2:

                            Long();
                            Time_C = float.Parse(Gakufu[Line, 6]) + plus;
                            break;

                        case 3:

                            Damage();
                            Time_C = float.Parse(Gakufu[Line, 6]) + plus;
                            break;

                        case 6:

                            Hold();
                            Time_C = float.Parse(Gakufu[Line, 6]) + plus;
                            break;

                        case -10:

                            Event();
                            Time_C = float.Parse(Gakufu[Line, 6]) + plus;
                            break;

                        case -11:
                            Shift01();
                            Time_C = float.Parse(Gakufu[Line, 6]) + plus;
                            break;

                        case -12:
                            Shift02();
                            Time_C = float.Parse(Gakufu[Line, 6]) + plus;
                            break;

                        case -13:
                            Shift03();
                            Time_C = float.Parse(Gakufu[Line, 6]) + plus;
                            break;

                        default:
                            Debug.Log("error in Gakufu[,]" + Line);
                            break;

                    }
                }
            }
        }
        //リザルト画面のシーン遷移
        else if (Time_now >= 10.0f && !audioSource.isPlaying && Time.timeScale != 0 && flac_End == 0 && (BGA == null || !BGA.GetComponent<VideoPlayer>().isPlaying))
        {
            flac_End = 2;
            Invoke("ResultTrans", 1.5f);
        }
    }
    void ResultTrans()
    {
        SceneManager.LoadScene("Result");
    }
    void Music_Play()
    {
        if (BGA != null)
        {
            BGA.GetComponent<VideoPlayer>().Play();
            Debug.Log(BGA.name);
        }
        audioSource.Play();
    }
    void OnGUI()
    {
        GUIStyle style00 = new GUIStyle(GUI.skin.button);
        style00.normal.textColor = Color.white;
        style00.fontSize = Convert.ToInt32(Screen.width * 40.0f / 1000.0f);
        // ボタンを表示する
        if (GUI.Button(new Rect(Screen.width / 2.15f, Screen.height / 95.0f, Screen.width / 15.0f, Screen.width / 15.0f), state_1, style00))
        {
            Debug.Log("Button is clicked.");
            if (stopped == false)
            {
                PauseUI.gameObject.SetActive(true);
                stopped = true;
                state_1 = " ▶ ";
                if (BGA != null)
                {
                    BGA.GetComponent<VideoPlayer>().Pause();
                    Debug.Log(BGA.name);
                }
                //Instantiate(PauseUI, new Vector3(0, 0, 0), transform.rotation);
                Time.timeScale = 0f;
                audioSource.Pause();
            }
            else
            {
                state_1 = " | | ";

                stopped = false;
                if (BGA != null)
                {
                    BGA.GetComponent<VideoPlayer>().Play();
                    Debug.Log(BGA.name);
                }
                Time.timeScale = 1f;
                audioSource.UnPause();
                PauseUI.gameObject.SetActive(false);
            }

        }
    }
    void Note()
    {
        Lane = int.Parse(Gakufu[Line, 1]);
        //速度倍率の取得
        magnification = float.Parse(Gakufu[Line, 2]);
        //temp = Instantiate(notes, new Vector3(-6 + Lane * 2, -4.0f + 10.0f * magnification + Event_object.transform.position.y, 0), transform.rotation);
        temp = Instantiate(notes, new Vector3(-6 + Lane * 2 + Shift_Slip, 6.0f + Event_object.transform.position.y, 0), transform.rotation);
        //dowmspeedに干渉
        if (Player_Mode == false)
        {
            temp.GetComponent<Notes>().enabled = false;
            temp.GetComponent<Notes_auto>().enabled = true;
            temp.GetComponent<Notes_auto>().Speed_C(SPEED * magnification);
            temp.GetComponent<Notes_auto>().Set_Time(float.Parse(Gakufu[Line, 3]) + plus);
            temp.GetComponent<Notes_auto>().Set_Lane(Lane, Event_object, Effect, Wall_Effect);
            if (Shift_Flag)
            {
                temp.GetComponent<Notes_auto>().Set_Shift(Shift_Times, X_Pace, Shift_Direction, Shift_Round_Time, Shift_Last_Round, Shift_Type);
                Shift_Flag = false;
                Shift_Times = 0;
                Shift_Round_Time = 0.0f;
                Shift_Direction = 0;
                Shift_Times = 0;
                X_Pace = 0.0f;
                Shift_Timing = 0;
                Shift_Type = 0;
                Shift_Last_Round = 0.0f;
                Shift_Slip = 0.0f;
            }
        }
        else
        {
            temp.GetComponent<Notes>().Set_Lane(Lane, Event_object, Effect);
            temp.GetComponent<Notes>().enabled = true;
            temp.GetComponent<Notes_auto>().enabled = false;
            temp.GetComponent<Notes>().Speed_C(SPEED * magnification);
            temp.GetComponent<Notes>().Set_Time(float.Parse(Gakufu[Line, 3]) + plus);
            temp.transform.Find("under").GetComponent<BoxCollider2D>().size = new Vector2(1.0f, SPEED / 2.0f);
            temp.transform.Find("under").transform.localPosition = new Vector3(0.0f, -SPEED / 4.0f, 1.0f);
            if (Shift_Flag)
            {
                temp.GetComponent<Notes>().Set_Shift(Shift_Times, X_Pace, Shift_Direction, Shift_Round_Time, Shift_Last_Round, Shift_Type);
                Shift_Flag = false;
                Shift_Times = 0;
                Shift_Round_Time = 0.0f;
                Shift_Direction = 0;
                Shift_Times = 0;
                X_Pace = 0.0f;
                Shift_Timing = 0;
                Shift_Type = 0;
                Shift_Last_Round = 0.0f;
                Shift_Slip = 0.0f;
            }
        }
        temp.transform.parent = Fild_Now.transform;
        temp.name = "notes";
        Line++;
    }
    void Long()
    {
        Lane = int.Parse(Gakufu[Line, 1]);
        //速度倍率の取得
        magnification = float.Parse(Gakufu[Line, 2]);
        temp = Instantiate(long_notes, new Vector3(-6 + Lane * 2 + Shift_Slip, 6.0f + Event_object.transform.position.y, 0), transform.rotation);
        //temp = Instantiate(long_notes, new Vector3(-6 + 2 * Lane, -4.0f + 10.0f * magnification + Event_object.transform.position.y, 0), transform.rotation);
        //dowmspeedに干渉
        float ysize = float.Parse(Gakufu[Line, 5]);//Size取得
        //sizeに干渉
        Vector3 size = temp.transform.localScale;
        size.y = -1.0f * System.Math.Abs(ysize * SPEED * (20.0f / 3.0f));
        temp.transform.localScale = size;
        if (Player_Mode == false)
        {
            //temp.GetComponent<Long_Head_auto>().Set_Val(size.y / -30.0f);
            temp.GetComponent<Long_Head>().enabled = false;
            temp.GetComponent<Long_Head_auto>().enabled = true;
            temp.GetComponent<Long_Head_auto>().Set_Lane(Lane, Event_object, Effect, Wall_Effect);
            temp.GetComponent<Long_Head_auto>().Speed_C(SPEED * magnification);
            temp.GetComponent<Long_Head_auto>().Set_Time(new Vector2(float.Parse(Gakufu[Line, 3]) + plus, ysize));
            if (Shift_Flag)
            {
                temp.GetComponent<Long_Head_auto>().Set_Shift(Shift_Times, X_Pace, Shift_Direction, Shift_Round_Time, Shift_Last_Round, Shift_Type);
                Shift_Flag = false;
                Shift_Times = 0;
                Shift_Round_Time = 0.0f;
                Shift_Direction = 0;
                Shift_Times = 0;
                X_Pace = 0.0f;
                Shift_Timing = 0;
                Shift_Type = 0;
                Shift_Last_Round = 0.0f;
                Shift_Slip = 0.0f;
            }
        }
        else
        {
            //temp.GetComponent<Long_Head>().Set_Val(size.y / -30.0f);
            temp.GetComponent<Long_Head>().Set_Lane(Lane, Event_object, Effect);
            temp.GetComponent<Long_Head>().enabled = true;
            temp.GetComponent<Long_Head_auto>().enabled = false;
            temp.GetComponent<Long_Head>().Speed_C(SPEED * magnification);
            temp.GetComponent<Long_Head>().Set_Time(new Vector2(float.Parse(Gakufu[Line, 3]) + plus, ysize));
            int cnt, ch = temp.transform.childCount;
            temp.transform.Find("under").GetComponent<BoxCollider2D>().size = new Vector2(1.0f, SPEED / 2.0f);
            temp.transform.Find("under").transform.localPosition = new Vector3(0.0f, SPEED / 4.0f, 1.0f);
            if (Shift_Flag)
            {
                temp.GetComponent<Long_Head>().Set_Shift(Shift_Times, X_Pace, Shift_Direction, Shift_Round_Time, Shift_Last_Round, Shift_Type);
                Shift_Flag = false;
                Shift_Times = 0;
                Shift_Round_Time = 0.0f;
                Shift_Direction = 0;
                Shift_Times = 0;
                X_Pace = 0.0f;
                Shift_Timing = 0;
                Shift_Type = 0;
                Shift_Last_Round = 0.0f;
                Shift_Slip = 0.0f;
            }
        }
        temp.transform.parent = Fild_Now.transform;
        temp.name = "Long_Note";
        Line++;
    }
    void Damage()
    {
        Lane = int.Parse(Gakufu[Line, 1]);
        //速度倍率の取得
        magnification = float.Parse(Gakufu[Line, 2]);
        temp = Instantiate(damage_notes, new Vector3(-6 + Lane * 2 + Shift_Slip, 6.0f + Event_object.transform.position.y, 0), transform.rotation);
        //temp = Instantiate(damage_notes, new Vector3(-6 + 2 * Lane, -4.0f + 10.0f * magnification + Event_object.transform.position.y, 0), transform.rotation);
        //dowmspeedに干渉
        if (Player_Mode == false)
        {
            temp.GetComponent<Damage_Note>().enabled = false;
            temp.GetComponent<Notes_auto>().enabled = true;
            temp.GetComponent<Notes_auto>().Speed_C(SPEED * magnification);
            temp.GetComponent<Notes_auto>().Set_Time(float.Parse(Gakufu[Line, 3]) + plus);
            temp.GetComponent<Notes_auto>().Set_Lane(Lane, Event_object, Effect, Wall_Effect);
            if (Shift_Flag)
            {
                temp.GetComponent<Notes_auto>().Set_Shift(Shift_Times, X_Pace, Shift_Direction, Shift_Round_Time, Shift_Last_Round, Shift_Type);
                Shift_Flag = false;
                Shift_Times = 0;
                Shift_Round_Time = 0.0f;
                Shift_Direction = 0;
                Shift_Times = 0;
                X_Pace = 0.0f;
                Shift_Timing = 0;
                Shift_Type = 0;
                Shift_Last_Round = 0.0f;
                Shift_Slip = 0.0f;
            }
        }
        else
        {
            temp.GetComponent<Damage_Note>().Set_Lane(Lane, Event_object, Effect);
            temp.GetComponent<Damage_Note>().enabled = true;
            temp.GetComponent<Notes_auto>().enabled = false;
            temp.GetComponent<Damage_Note>().Speed_C(SPEED * magnification);
            temp.GetComponent<Damage_Note>().Set_Time(float.Parse(Gakufu[Line, 3]) + plus);
            temp.transform.GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(1.0f, SPEED / 2.0f);
            temp.transform.GetChild(0).transform.localPosition = new Vector3(0.0f, SPEED / 4.0f, 1.0f);
            if (Shift_Flag)
            {
                temp.GetComponent<Damage_Note>().Set_Shift(Shift_Times, X_Pace, Shift_Direction, Shift_Round_Time, Shift_Last_Round, Shift_Type);
                Shift_Flag = false;
                Shift_Times = 0;
                Shift_Round_Time = 0.0f;
                Shift_Direction = 0;
                Shift_Times = 0;
                X_Pace = 0.0f;
                Shift_Timing = 0;
                Shift_Type = 0;
                Shift_Last_Round = 0.0f;
                Shift_Slip = 0.0f;
            }
        }
        temp.name = "Damage_Note";
        temp.transform.parent = Fild_Now.transform;
        Line++;
    }
    void Hold()
    {
        Lane = int.Parse(Gakufu[Line, 1]);
        //速度倍率の取得
        magnification = float.Parse(Gakufu[Line, 2]);
        temp = Instantiate(hold_notes, new Vector3(-6 + Lane * 2 + Shift_Slip, 6.0f + Event_object.transform.position.y, 0), transform.rotation);
        //temp = Instantiate(hold_notes, new Vector3(-6 + 2 * Lane, -4.0f + 10.0f * magnification + Event_object.transform.position.y, 0), transform.rotation);
        //dowmspeedに干渉
        if (Player_Mode == false)
        {
            temp.GetComponent<Hold_Note>().enabled = false;
            temp.GetComponent<Notes_auto>().enabled = true;
            temp.GetComponent<Notes_auto>().Speed_C(SPEED * magnification);
            temp.GetComponent<Notes_auto>().Set_Time(float.Parse(Gakufu[Line, 3]) + plus);
            temp.GetComponent<Notes_auto>().Set_Lane(Lane, Event_object, Effect, Wall_Effect);
            if (Shift_Flag)
            {
                temp.GetComponent<Notes_auto>().Set_Shift(Shift_Times, X_Pace, Shift_Direction, Shift_Round_Time, Shift_Last_Round, Shift_Type);
                Shift_Flag = false;
                Shift_Times = 0;
                Shift_Round_Time = 0.0f;
                Shift_Direction = 0;
                Shift_Times = 0;
                X_Pace = 0.0f;
                Shift_Timing = 0;
                Shift_Type = 0;
                Shift_Last_Round = 0.0f;
                Shift_Slip = 0.0f;
            }
        }
        else
        {
            temp.GetComponent<Hold_Note>().Set_Lane(Lane, Event_object, Effect);
            temp.GetComponent<Hold_Note>().enabled = true;
            temp.GetComponent<Notes_auto>().enabled = false;
            temp.GetComponent<Hold_Note>().Speed_C(SPEED * magnification);
            temp.GetComponent<Hold_Note>().Set_Time(float.Parse(Gakufu[Line, 3]) + plus);
            temp.transform.GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(1.0f, SPEED / 2.0f);
            temp.transform.GetChild(0).transform.localPosition = new Vector3(0.0f, -SPEED / 4.0f, 1.0f);
            if (Shift_Flag)
            {
                temp.GetComponent<Hold_Note>().Set_Shift(Shift_Times, X_Pace, Shift_Direction, Shift_Round_Time, Shift_Last_Round, Shift_Type);
                Shift_Flag = false;
                Shift_Times = 0;
                Shift_Round_Time = 0.0f;
                Shift_Direction = 0;
                Shift_Times = 0;
                X_Pace = 0.0f;
                Shift_Timing = 0;
                Shift_Type = 0;
                Shift_Last_Round = 0.0f;
                Shift_Slip = 0.0f;
            }
        }
        temp.name = "Hold_Note";
        temp.transform.parent = Fild_Now.transform;
        Line++;
    }
    void Event()
    {
        Event_object.GetComponent<Test_Event>().SetID(EVENTID, SPEED, gameObject);
        Line++;
    }
    void Shift01()
    {
        /*  Shift_Status
         *  -11(Fixed),Slip,Magnification,Time,1(Fixed),Times,
         *注釈文だ！喜べ(本人も理解できない)
         */
        //回数指定ができる、ブレさせることができるタイプ
        //馬鹿みたいに高い値を指定するとバグる
        Shift_Flag = true;
        Shift_Slip = float.Parse(Gakufu[Line, 1]);
        Shift_Times = int.Parse(Gakufu[Line, 5]);
        if (Shift_Times % 2 == 0)
        {
            Shift_Times++;
        }
        if (Shift_Slip < 0)
        {
            Shift_Direction = 1;
        }
        else
        {
            Shift_Direction = -1;
        }
        X_Pace = System.Math.Abs(Shift_Slip) * Shift_Times / (10.0f / (SPEED * float.Parse(Gakufu[Line, 2])));
        Shift_Round_Time = (10.0f / (SPEED * float.Parse(Gakufu[Line, 2]))) / Shift_Times;
        Shift_Last_Round = (10.0f / (SPEED * float.Parse(Gakufu[Line, 2]))) - Shift_Round_Time * (Shift_Times - 1);
        Shift_Type = 1;
        Line++;
    }
    void Shift02()
    {
        /*  Shift_Status
         *  -12(Fixed),Slip,Magnification,Time,1(Fixed),Timing,
         */
        //指定位置で一瞬で一回ずれるタイプ
        Shift_Flag = true;
        Shift_Slip = float.Parse(Gakufu[Line, 1]);
        Shift_Timing = float.Parse(Gakufu[Line, 5]);
        if (Shift_Slip < 0)
        {
            Shift_Direction = 1;
        }
        else
        {
            Shift_Direction = -1;
        }
        //X_Pace = System.Math.Abs(Shift_Slip) / ((10.0f / Shift_Timing) / (SPEED * float.Parse(Gakufu[Line, 2])));
        Shift_Times = 2;
        Shift_Round_Time = (10.0f / (SPEED * float.Parse(Gakufu[Line, 2]))) * (Shift_Timing / 10.0f);
        Shift_Last_Round = 0.05f * System.Math.Abs(Shift_Slip) / (SPEED * float.Parse(Gakufu[Line, 2]));
        X_Pace = System.Math.Abs(Shift_Slip) / Shift_Last_Round;
        Shift_Type = 2;
        Line++;
    }
    void Shift03()
    {
        /*  Shift_Status
         *  -12(Fixed),Slip,Magnification,Time,1(Fixed),Timing,
         *  指定位置で本来のレーンに戻るタイプ
         */
        Shift_Flag = true;
        Shift_Slip = float.Parse(Gakufu[Line, 1]);
        Shift_Times = 1;
        Shift_Timing = float.Parse(Gakufu[Line, 5]);
        if (Shift_Slip < 0)
        {
            Shift_Direction = 1;
        }
        else
        {
            Shift_Direction = -1;
        }
        Shift_Round_Time = (10.0f / (SPEED * float.Parse(Gakufu[Line, 2]))) * (Shift_Timing / 10.0f);
        Shift_Last_Round = (10.0f / (SPEED * float.Parse(Gakufu[Line, 2]))) * (Shift_Timing / 10.0f);
        X_Pace = System.Math.Abs(Shift_Slip) / (10.0f / (SPEED * float.Parse(Gakufu[Line, 2])) * (Shift_Timing / 10.0f));
        Shift_Type = 3;
        Line++;
    }
    void Random_Shift_03()
    {
        Shift_Flag = true;
        Shift_Slip = UnityEngine.Random.Range(-25, 25);
        Shift_Times = 1;
        Shift_Timing = 5.0f;
        if (Shift_Slip < 0)
        {
            Shift_Direction = 1;
        }
        else
        {
            Shift_Direction = -1;
        }
        Shift_Round_Time = (10.0f / (SPEED * float.Parse(Gakufu[Line, 2]))) * (Shift_Timing / 10.0f);
        Shift_Last_Round = (10.0f / (SPEED * float.Parse(Gakufu[Line, 2]))) * (Shift_Timing / 10.0f);
        X_Pace = System.Math.Abs(Shift_Slip) / (10.0f / (SPEED * float.Parse(Gakufu[Line, 2])) * (Shift_Timing / 10.0f));
        Shift_Type = 3;
    }
    void Random_Shift_02()
    {
        Shift_Flag = true;
        Shift_Slip = UnityEngine.Random.Range(-6.0f, 6.0f);
        Shift_Timing = 8.5f;
        //Shift_Slip = -1 * 2.0f;
        if (Shift_Slip < 0)
        {
            Shift_Direction = 1;
            Shift_Slip = -2.0f;
        }
        else
        {
            Shift_Slip = 2.0f;
            Shift_Direction = -1;
        }
        Shift_Slip = Shift_Direction * 2.0f * -1;
        //X_Pace = System.Math.Abs(Shift_Slip) / ((10.0f / Shift_Timing) / (SPEED * float.Parse(Gakufu[Line, 2])));
        Shift_Times = 2;
        Shift_Round_Time = (10.0f / (SPEED * float.Parse(Gakufu[Line, 2]))) * (Shift_Timing / 10.0f);
        Shift_Last_Round = 0.1f * System.Math.Abs(Shift_Slip) / (SPEED * float.Parse(Gakufu[Line, 2]));
        X_Pace = System.Math.Abs(Shift_Slip) / Shift_Last_Round;
        Shift_Type = 2;
    }
    void Random_Shift_01()
    {
        Shift_Flag = true;
        Shift_Slip = UnityEngine.Random.Range(-25, 25);
        Shift_Slip = 10.0f;
        Shift_Times = 1;
        if (int.Parse(Gakufu[Line, 1]) > 3)
        {
            Shift_Slip *= -1.0f;
        }
        else if (int.Parse(Gakufu[Line, 1]) == 3)
        {
            Shift_Slip = 0;
        }
        if (Shift_Slip < 0)
        {
            Shift_Direction = 1;
        }
        else
        {
            Shift_Direction = -1;
        }
        Shift_Type = 1;
        X_Pace = System.Math.Abs(Shift_Slip) * Shift_Times / (10.0f / (SPEED * float.Parse(Gakufu[Line, 2])));
        Shift_Round_Time = (10.0f / (SPEED * float.Parse(Gakufu[Line, 2]))) / Shift_Times;
        Shift_Last_Round = (10.0f / (SPEED * float.Parse(Gakufu[Line, 2]))) - Shift_Round_Time * (Shift_Times - 1);
    }
    public float Time_NOW_ADD(float n)
    {
        float a = Time_now, b = float.Parse(Gakufu[Line, 3]) + plus;
        Time_now = Time_C = float.Parse(Gakufu[Line, 3]) + plus;
        Time_now -= n;
        return b - a + (10.0f / SPEED - n);
    }
    public void Switch_Field(int N)
    {
        if (N == 1)
        {
            Fild_Now = Field1;
        }
        else if (N == 2)
        {
            Fild_Now = Field2;
        }
        else
        {
            Debug.Log("指定ミスか未定義 N:" + N);
        }
    }
    public void Field_Open(int N)
    {
        if (N == 1)
        {
            Field1.GetComponent<Event_F_C>().Set_F(true);
        }
        else if (N == 2)
        {
            Field2.GetComponent<Event_F_C>().Set_F(true);
        }
        else
        {
            Debug.Log("指定ミスか未定義 N:" + N);
        }
    }
    public void Field_Close(int N)
    {
        if (N == 1)
        {
            Field1.GetComponent<Event_F_C>().Set_F(false);
        }
        else if (N == 2)
        {
            Field2.GetComponent<Event_F_C>().Set_F(false);
        }
        else
        {
            Debug.Log("指定ミスか未定義 N:" + N);
        }
    }
    public int Combo_Max()
    {
        return int.Parse(Gakufu[0, 4]);
    }
}