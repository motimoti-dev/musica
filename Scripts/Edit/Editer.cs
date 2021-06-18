using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Editer : MonoBehaviour {

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
    GameObject PauseUI;

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
    float music_c;
    private float constant = 10.0f;


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
    private GameObject Event_object;
    void Start()
    {
        Event_object = Camera.main.gameObject;
        //
        Line = 0;
        Time_C = 0;
        Time_now = 0;
        flac_End = 0;
        NewMethod();
        //オーディオソースの取得
        audioSource = gameObject.GetComponent<AudioSource>();
        //ポーズUIの取得
        PauseUI = GameObject.Find("PauseUI");
        PauseUI.gameObject.SetActive(false);
        /*
        //テキストアセット
        TextAsset textasset = new TextAsset();
        //テキストファイルのデータを取得するインスタンスを作成
        textasset = Resources.Load("test", typeof(TextAsset)) as TextAsset;
        
        //Resourcesフォルダから対象テキストを取得
        string TextLines = textasset.text;
        */
        string TextLines = text.text;
        //テキスト全体をstring型で入れる変数を用意して入れる

        //Splitで一行づつを代入した1次配列を作成
        textMessage = TextLines.Split('\n');

        //行数と列数を取得
        rowLength = textMessage.Length;

        //2次配列を定義
        Gakufu = new string[rowLength, 6];
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
        delay = constant / SPEED;
        plus = float.Parse(Gakufu[0, 1]);
    }

    private void NewMethod()
    {
        state_1 = " | | ";
    }
    void Update()
    {
        //ここを変えない（ささけ）
        Time_now += Time.deltaTime;
        //エンドフラグ
        flac_End = 1;

        if (Time_now >= Time_C)
        {
            if (flac_End == 1)
            {
                Parameter = int.Parse(Gakufu[Line, 0]);
                simultaneous = int.Parse(Gakufu[Line, 4]);
                for (int c = 0; c < simultaneous + 1; c++)
                {
                    switch (Parameter)
                    {
                        case -1:
                            //-1で終了
                            flac_End = 0;
                            break;

                        case 0:
                            //0で音楽開始
                            Invoke("Music_Play", delay);
                            Line++;
                            Time_C = float.Parse(Gakufu[Line, 3]) + plus;
                            break;

                        case 1:

                            Note();
                            Time_C = float.Parse(Gakufu[Line, 3]) + plus;
                            break;

                        case 2:

                            Long();
                            Time_C = float.Parse(Gakufu[Line, 3]) + plus;
                            break;

                        case 3:

                            Damage();
                            Time_C = float.Parse(Gakufu[Line, 3]) + plus;
                            break;

                        case 6:

                            Hold();
                            Time_C = float.Parse(Gakufu[Line, 3]) + plus;
                            break;

                        default:
                            Debug.Log("error in Gakufu[,]" + Line);
                            break;

                    }
                }
            }
        }
        //リザルト画面のシーン遷移
        if (Time_now >= 10.0f && !audioSource.isPlaying && Time.timeScale != 0 && flac_End == 0)
        {
            Invoke("ResultTrans", 1.5f);
        }
    }
    void ResultTrans()
    {
        SceneManager.LoadScene("Result");
    }
    void Music_Play()
    {

        audioSource.Play();

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
                state_1 = " ? ";
                //Instantiate(PauseUI, new Vector3(0, 0, 0), transform.rotation);
                Time.timeScale = 0f;
                audioSource.Pause();
            }
            else
            {
                state_1 = " | | ";

                stopped = false;
                Time.timeScale = 1f;
                audioSource.UnPause();
                PauseUI.gameObject.SetActive(false);
            }

        }
    }
    void Note()
    {
        Lane = int.Parse(Gakufu[Line, 1]);
        switch (Lane)
        {


            case 0:
                //あとで速度代入
                temp = Instantiate(notes, new Vector3(-6f, 6f + Event_object.transform.position.y, 0), transform.rotation);
                break;

            case 1:
                //あとで速度代入
                temp = Instantiate(notes, new Vector3(-4f, 6f + Event_object.transform.position.y, 0), transform.rotation);
                break;

            case 2:
                //あとで速度代入
                temp = Instantiate(notes, new Vector3(-2f, 6f + Event_object.transform.position.y, 0), transform.rotation);
                break;

            case 3:
                //あとで速度代入
                temp = Instantiate(notes, new Vector3(0, 6f + Event_object.transform.position.y, 0), transform.rotation);
                break;

            case 4:
                //あとで速度代入
                temp = Instantiate(notes, new Vector3(2f, 6f + Event_object.transform.position.y, 0), transform.rotation);
                break;

            case 5:
                //あとで速度代入
                temp = Instantiate(notes, new Vector3(4f, 6f + Event_object.transform.position.y, 0), transform.rotation);
                break;

            case 6:
                //あとで速度代入
                temp = Instantiate(notes, new Vector3(6f, 6f + Event_object.transform.position.y, 0), transform.rotation);
                break;


        }
        //速度倍率の取得
        magnification = float.Parse(Gakufu[Line, 2]);
        //dowmspeedに干渉
        temp.GetComponent<Notes>().Speed_C(SPEED * magnification);
        temp.GetComponent<Notes_auto>().Speed_C(SPEED * magnification);
        //object名を変更
        temp.name = Gakufu[Line, 3];
        Line++;
    }
    void Long()
    {
        Lane = int.Parse(Gakufu[Line, 1]);
        switch (Lane)
        {
            case 0:
                //あとで速度代入
                temp = Instantiate(long_notes, new Vector3(-6f, 6f + Event_object.transform.position.y, 0), transform.rotation);
                break;

            case 1:
                //あとで速度代入
                temp = Instantiate(long_notes, new Vector3(-4f, 6f + Event_object.transform.position.y, 0), transform.rotation);
                break;

            case 2:
                //あとで速度代入
                temp = Instantiate(long_notes, new Vector3(-2f, 6f + Event_object.transform.position.y, 0), transform.rotation);
                break;

            case 3:
                //あとで速度代入
                temp = Instantiate(long_notes, new Vector3(0, 6f + Event_object.transform.position.y, 0), transform.rotation);
                break;

            case 4:
                //あとで速度代入
                temp = Instantiate(long_notes, new Vector3(2f, 6f + Event_object.transform.position.y, 0), transform.rotation);
                break;

            case 5:
                //あとで速度代入
                temp = Instantiate(long_notes, new Vector3(4f, 6f + Event_object.transform.position.y, 0), transform.rotation);
                break;

            case 6:
                //あとで速度代入
                temp = Instantiate(long_notes, new Vector3(6f, 6f + Event_object.transform.position.y, 0), transform.rotation);
                break;


        }
        //速度倍率の取得
        magnification = float.Parse(Gakufu[Line, 2]);
        //dowmspeedに干渉
        temp.GetComponent<Long_Head>().Speed_C(SPEED * magnification);
        temp.GetComponent<Long_Head_auto>().Speed_C(SPEED * magnification);

        //sizeに干渉
        Vector3 size = temp.transform.localScale;
        float ysize = float.Parse(Gakufu[Line, 5]);
        size.y = -1 * ysize * SPEED * 10;
        temp.transform.localScale = size;
        //object名を変更
        temp.name = Gakufu[Line, 3];
        Line++;
    }
    void Damage()
    {
        Lane = int.Parse(Gakufu[Line, 1]);
        switch (Lane)
        {


            case 0:
                //あとで速度代入
                temp = Instantiate(damage_notes, new Vector3(-6f, 6f + Event_object.transform.position.y, 0), transform.rotation);
                break;

            case 1:
                //あとで速度代入
                temp = Instantiate(damage_notes, new Vector3(-4f, 6f + Event_object.transform.position.y, 0), transform.rotation);
                break;

            case 2:
                //あとで速度代入
                temp = Instantiate(damage_notes, new Vector3(-2f, 6f + Event_object.transform.position.y, 0), transform.rotation);
                break;

            case 3:
                //あとで速度代入
                temp = Instantiate(damage_notes, new Vector3(0, 6f + Event_object.transform.position.y, 0), transform.rotation);
                break;

            case 4:
                //あとで速度代入
                temp = Instantiate(damage_notes, new Vector3(2f, 6f + Event_object.transform.position.y, 0), transform.rotation);
                break;

            case 5:
                //あとで速度代入
                temp = Instantiate(damage_notes, new Vector3(4f, 6f + Event_object.transform.position.y, 0), transform.rotation);
                break;

            case 6:
                //あとで速度代入
                temp = Instantiate(damage_notes, new Vector3(6f, 6f + Event_object.transform.position.y, 0), transform.rotation);
                break;


        }
        //速度倍率の取得
        magnification = float.Parse(Gakufu[Line, 2]);
        //dowmspeedに干渉
        temp.GetComponent<Damage_Note>().Speed_C(SPEED * magnification);
        temp.GetComponent<Damage_Notes_auto>().Speed_C(SPEED * magnification);
        //object名を変更
        temp.name = Gakufu[Line, 3];
        Line++;
    }
    void Hold()
    {
        Lane = int.Parse(Gakufu[Line, 1]);
        switch (Lane)
        {


            case 0:
                //あとで速度代入
                temp = Instantiate(hold_notes, new Vector3(-6f, 6f + Event_object.transform.position.y, 0), transform.rotation);
                break;

            case 1:
                //あとで速度代入
                temp = Instantiate(hold_notes, new Vector3(-4f, 6f + Event_object.transform.position.y, 0), transform.rotation);
                break;

            case 2:
                //あとで速度代入
                temp = Instantiate(hold_notes, new Vector3(-2f, 6f + Event_object.transform.position.y, 0), transform.rotation);
                break;

            case 3:
                //あとで速度代入
                temp = Instantiate(hold_notes, new Vector3(0, 6f + Event_object.transform.position.y, 0), transform.rotation);
                break;

            case 4:
                //あとで速度代入
                temp = Instantiate(hold_notes, new Vector3(2f, 6f + Event_object.transform.position.y, 0), transform.rotation);
                break;

            case 5:
                //あとで速度代入
                temp = Instantiate(hold_notes, new Vector3(4f, 6f + Event_object.transform.position.y, 0), transform.rotation);
                break;

            case 6:
                //あとで速度代入
                temp = Instantiate(hold_notes, new Vector3(6f, 6f + Event_object.transform.position.y, 0), transform.rotation);
                break;


        }
        //速度倍率の取得
        magnification = float.Parse(Gakufu[Line, 2]);
        //dowmspeedに干渉
        temp.GetComponent<Hold_Note>().Speed_C(SPEED * magnification);
        temp.GetComponent<Notes_auto>().Speed_C(SPEED * magnification);
        //object名を変更
        temp.name = Gakufu[Line, 3];
        Line++;
    }
}
