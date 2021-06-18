using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;


public class Load_Map : MonoBehaviour
{

    StreamWriter writer;
    StreamReader reader;
    public Data data_score;
    Data data1;
    public GameObject Text_1st;
    public GameObject Text_2nd;
    public GameObject Text_3rd;
    public GameObject SOUND_NAME;
    public GameObject Cube;
    //flacs
    public int flac_Set = 0;
    //各方向スワイプの検知変数　
    public static int Left = 0, Right = 0, Up = 0, Down = 0;

    public void Save()
    {

        Debug.Log("save");

        try
        {


            Data data1 = null;
            data1 = Load("");
            writer = new StreamWriter(Application.dataPath + "/Save/Save_Data.json", false);
            //for()

            data1.score_1st = 1000000;
            data1.score_2st = 900000;
            data1.score_3st = 800000;
            string jsonstr = JsonUtility.ToJson(data1);
            writer.Write(jsonstr);
            writer.Flush();
        }
        catch (IOException)
        {
            Debug.Log("ファイルオープンエラー");
        }
        finally
        {
            if (writer != null)
            {
                Debug.Log("Close");
                writer.Close();
            }
        }

    }
    public void Start()
    {
        GameObject Camera_Object = Camera.main.gameObject;
        Text_1st = Camera_Object.transform.Find("Canvas").transform.Find("1st").gameObject;
        Text_2nd = Camera_Object.transform.Find("Canvas").transform.Find("2nd").gameObject;
        Text_3rd = Camera_Object.transform.Find("Canvas").transform.Find("3rd").gameObject;
        SOUND_NAME = Camera_Object.transform.Find("Canvas").transform.Find("SOUND_NAME").gameObject;
        Cube = Camera_Object.transform.Find("Cube").gameObject;
        //曲数いれて[ここ]
        //絶対にMusicCのスイッチ文に追加する。
        string[] Music = new string[] { "FD","Charles", "Evans", "harehare","UMR","connect",
            "sobakasu","tooriyo","EndMark","DoD", "Doppel", "MikuGeki", "MikuShou",
                                        "MikuShouGeki" ,"PUPA","vs"};
        string sound;
        //初期の曲マップの番号0でFDから
        //int sound_local;

        sound = "data1." + Music[0] + "_E_1st";
        Debug.Log(sound);
        int Songs;
        Songs = Music.Length;
        //
        //データ生成時ここでcall
        //Save();
        Transform Transform = Camera.main.transform;
        Vector3 Pos = Transform.position;
        if (Up != 0)
        {
            int addp = 0;
            addp = Up * 10;
            Pos.y = addp;
        }
        if (Right != 0) {
            int addp = 0;
            addp = Right * -18;
            Pos.x = addp;
        }
        Transform.position = Pos;
        //Camera.main.transform.position.x = 
    }
    //--------------------------------------------------------------------------------------------------------
    //それぞれのText1st 2nd 3rd に受け渡す
    /*
    public void FD(Data data1) {
        //easy
        
        Debug.Log("FD");曲名を出す
        ここではテキストの変更
        Text_1st.GetComponent<Text_1st>().ScoreChanger(data1.FD_E_1st);
        Debug.Log("1st:" + data1.FD_E_1st);

        Text_2nd.GetComponent<Text_2nd>().ScoreChanger(data1.FD_E_2nd);
        Debug.Log("2st:" + data1.FD_E_2nd);

        Text_3rd.GetComponent<Text_3rd>().ScoreChanger(data1.FD_E_3rd);
        Debug.Log("3st:" + data1.FD_E_3rd);

    }  
         
    */
    public void Error_location()
    {

        Debug.Log("out of location");
        Text_1st.GetComponent<Text_1st>().ScoreChanger(0);
        Text_2nd.GetComponent<Text_2nd>().ScoreChanger(0);
        Text_3rd.GetComponent<Text_3rd>().ScoreChanger(0);

    }
    public void FD(Data data1)
    {
        //select画面の名前を変更
        if (SOUND_NAME != null)
        {
            SOUND_NAME.GetComponent<SOUND_NAME_C>().ChangeName("Freedom Dive ↓↓");
        }
        if (Up == 0)
        {
            //easy

            Debug.Log("FD");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(data1.FD_E_1st);
            Debug.Log("1st:" + data1.FD_E_1st);

            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(data1.FD_E_2nd);
            Debug.Log("2st:" + data1.FD_E_2nd);

            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(data1.FD_E_3rd);
            Debug.Log("3st:" + data1.FD_E_3rd);

            Cube.GetComponent<Box_roll>().pastel_green();
            Cube.GetComponent<Box_roll>().Mode_Change(0);
        }
        else if (Up == 1)
        {
            //nomal
            Debug.Log("FD");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(data1.FD_N_1st);
            Debug.Log("1st:" + data1.FD_N_1st);

            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(data1.FD_N_2nd);
            Debug.Log("2st:" + data1.FD_N_2nd);

            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(data1.FD_N_3rd);
            Debug.Log("3st:" + data1.FD_N_3rd);

            Cube.GetComponent<Box_roll>().turquoise();
            Cube.GetComponent<Box_roll>().Mode_Change(1);
        }
        else if (Up == 2)
        {
            //hard
            Debug.Log("FD");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(data1.FD_H_1st);
            Debug.Log("1st:" + data1.FD_H_1st);

            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(data1.FD_H_2nd);
            Debug.Log("2st:" + data1.FD_H_2nd);

            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(data1.FD_H_3rd);
            Debug.Log("3st:" + data1.FD_H_3rd);

            Cube.GetComponent<Box_roll>().pink();
            Cube.GetComponent<Box_roll>().Mode_Change(2);
        }
        else
        {
            Debug.Log("error location reset to 0");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(0);
            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(0);
            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(0);

            Cube.GetComponent<Box_roll>().black();
            Cube.GetComponent<Box_roll>().Mode_Change(0);
        }
    }
    public void Charles(Data data1)
    {
        //select画面の名前を変更
        SOUND_NAME.GetComponent<SOUND_NAME_C>().ChangeName("シャルル");
        if (Up == 0)
        {
            //easy

            Debug.Log("Charles");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(data1.Charles_E_1st);
            Debug.Log("1st:" + data1.FD_E_1st);

            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(data1.Charles_E_2nd);
            Debug.Log("2st:" + data1.FD_E_2nd);

            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(data1.Charles_E_3rd);
            Debug.Log("3st:" + data1.FD_E_3rd);

            Cube.GetComponent<Box_roll>().pastel_green();
            Cube.GetComponent<Box_roll>().Mode_Change(0);
        }
        else if (Up == 1)
        {
            //nomal
            Debug.Log("Charles");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(data1.Charles_N_1st);
            Debug.Log("1st:" + data1.FD_N_1st);

            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(data1.Charles_N_2nd);
            Debug.Log("2st:" + data1.FD_N_2nd);

            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(data1.Charles_N_3rd);
            Debug.Log("3st:" + data1.FD_N_3rd);

            Cube.GetComponent<Box_roll>().turquoise();
            Cube.GetComponent<Box_roll>().Mode_Change(1);
        }
        else if (Up == 2)
        {
            //hard
            Debug.Log("Charles");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(data1.Charles_H_1st);
            Debug.Log("1st:" + data1.FD_H_1st);

            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(data1.Charles_H_2nd);
            Debug.Log("2st:" + data1.FD_H_2nd);

            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(data1.Charles_H_3rd);
            Debug.Log("3st:" + data1.FD_H_3rd);

            Cube.GetComponent<Box_roll>().pink();
            Cube.GetComponent<Box_roll>().Mode_Change(2);
        }
        else
        {
            Debug.Log("error location reset to 0");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(0);
            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(0);
            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(0);

            Cube.GetComponent<Box_roll>().black();
            Cube.GetComponent<Box_roll>().Mode_Change(0);
        }
    }
    public void Evans(Data data1)
    {
        //select画面の名前を変更
        SOUND_NAME.GetComponent<SOUND_NAME_C>().ChangeName("Evans");
        if (Up == 0)
        {

            //easy
            Debug.Log("Evans");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(data1.Evans_E_1st);
            Debug.Log("1st:" + data1.Evans_E_1st);

            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(data1.Evans_E_2nd);
            Debug.Log("2st:" + data1.Evans_E_2nd);

            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(data1.Evans_E_3rd);
            Debug.Log("3st:" + data1.Evans_E_3rd);

            Cube.GetComponent<Box_roll>().pastel_green();
            Cube.GetComponent<Box_roll>().Mode_Change(0);
        }
        else if (Up == 1)
        {
            //nomal
            Debug.Log("Evans");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(data1.Evans_N_1st);
            Debug.Log("1st:" + data1.Evans_N_1st);

            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(data1.Evans_N_2nd);
            Debug.Log("2st:" + data1.Evans_N_2nd);

            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(data1.Evans_N_3rd);
            Debug.Log("3st:" + data1.Evans_N_3rd);

            Cube.GetComponent<Box_roll>().turquoise();
            Cube.GetComponent<Box_roll>().Mode_Change(1);

        }
        else if (Up == 2)
        {
            //hard
            Debug.Log("Evans");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(data1.Evans_H_1st);
            Debug.Log("1st:" + data1.Evans_H_1st);

            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(data1.Evans_H_2nd);
            Debug.Log("2st:" + data1.Evans_H_2nd);

            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(data1.Evans_H_3rd);
            Debug.Log("3st:" + data1.Evans_H_3rd);

            Cube.GetComponent<Box_roll>().pink();
            Cube.GetComponent<Box_roll>().Mode_Change(2);
        }
        else
        {
            Debug.Log("error location reset to 0");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(0);
            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(0);
            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(0);

            Cube.GetComponent<Box_roll>().black();
        }

    }
    public void tooriyo(Data data1)
    {
        //select画面の名前を変更
        SOUND_NAME.GetComponent<SOUND_NAME_C>().ChangeName("トオリヨ");
        if (Up == 0)
        {

            //easy
            Debug.Log("tooriyo");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(data1.tooriyo_E_1st);
            Debug.Log("1st:" + data1.tooriyo_E_1st);

            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(data1.tooriyo_E_2nd);
            Debug.Log("2st:" + data1.tooriyo_E_2nd);

            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(data1.tooriyo_E_3rd);
            Debug.Log("3st:" + data1.tooriyo_E_3rd);

            Cube.GetComponent<Box_roll>().pastel_green();
            Cube.GetComponent<Box_roll>().Mode_Change(0);
        }
        else if (Up == 1)
        {
            //nomal
            Debug.Log("tooriyo");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(data1.tooriyo_N_1st);
            Debug.Log("1st:" + data1.tooriyo_N_1st);

            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(data1.tooriyo_N_2nd);
            Debug.Log("2st:" + data1.tooriyo_N_2nd);

            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(data1.tooriyo_N_3rd);
            Debug.Log("3st:" + data1.tooriyo_N_3rd);

            Cube.GetComponent<Box_roll>().turquoise();
            Cube.GetComponent<Box_roll>().Mode_Change(1);

        }
        else if (Up == 2)
        {
            //hard
            Debug.Log("tooriyo");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(data1.tooriyo_H_1st);
            Debug.Log("1st:" + data1.tooriyo_H_1st);

            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(data1.tooriyo_H_2nd);
            Debug.Log("2st:" + data1.tooriyo_H_2nd);

            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(data1.tooriyo_H_3rd);
            Debug.Log("3st:" + data1.tooriyo_H_3rd);

            Cube.GetComponent<Box_roll>().pink();
            Cube.GetComponent<Box_roll>().Mode_Change(2);
        }
        else
        {
            Debug.Log("error location reset to 0");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(0);
            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(0);
            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(0);

            Cube.GetComponent<Box_roll>().black();
        }

    }
    public void UMR(Data data1)
    {
        //select画面の名前を変更
        SOUND_NAME.GetComponent<SOUND_NAME_C>().ChangeName("かくしん的☆めたまるふぉ〜ぜっ!");
        if (Up == 0)
        {

            //easy
            Debug.Log("UMR");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(data1.UMR_E_1st);
            Debug.Log("1st:" + data1.UMR_E_1st);

            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(data1.UMR_E_2nd);
            Debug.Log("2st:" + data1.UMR_E_2nd);

            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(data1.UMR_E_3rd);
            Debug.Log("3st:" + data1.UMR_E_3rd);

            Cube.GetComponent<Box_roll>().pastel_green();
            Cube.GetComponent<Box_roll>().Mode_Change(0);
        }
        else if (Up == 1)
        {
            //nomal
            Debug.Log("UMR");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(data1.UMR_N_1st);
            Debug.Log("1st:" + data1.UMR_N_1st);

            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(data1.UMR_N_2nd);
            Debug.Log("2st:" + data1.UMR_N_2nd);

            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(data1.UMR_N_3rd);
            Debug.Log("3st:" + data1.UMR_N_3rd);

            Cube.GetComponent<Box_roll>().turquoise();
            Cube.GetComponent<Box_roll>().Mode_Change(1);

        }
        else if (Up == 2)
        {
            //hard
            Debug.Log("UMR");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(data1.UMR_H_1st);
            Debug.Log("1st:" + data1.UMR_H_1st);

            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(data1.UMR_H_2nd);
            Debug.Log("2st:" + data1.UMR_H_2nd);

            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(data1.UMR_H_3rd);
            Debug.Log("3st:" + data1.UMR_H_3rd);

            Cube.GetComponent<Box_roll>().pink();
            Cube.GetComponent<Box_roll>().Mode_Change(2);
        }
        else
        {
            Debug.Log("error location reset to 0");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(0);
            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(0);
            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(0);

            Cube.GetComponent<Box_roll>().black();
        }

    }
    public void sobakasu(Data data1)
    {
        //select画面の名前を変更
        SOUND_NAME.GetComponent<SOUND_NAME_C>().ChangeName("そばかす");
        if (Up == 0)
        {

            //easy
            Debug.Log("sobakasu");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(data1.sobakasu_E_1st);
            Debug.Log("1st:" + data1.sobakasu_E_1st);

            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(data1.sobakasu_E_2nd);
            Debug.Log("2st:" + data1.sobakasu_E_2nd);

            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(data1.sobakasu_E_3rd);
            Debug.Log("3st:" + data1.sobakasu_E_3rd);

            Cube.GetComponent<Box_roll>().pastel_green();
            Cube.GetComponent<Box_roll>().Mode_Change(0);
        }
        else if (Up == 1)
        {
            //nomal
            Debug.Log("sobakasu");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(data1.sobakasu_N_1st);
            Debug.Log("1st:" + data1.sobakasu_N_1st);

            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(data1.sobakasu_N_2nd);
            Debug.Log("2st:" + data1.sobakasu_N_2nd);

            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(data1.sobakasu_N_3rd);
            Debug.Log("3st:" + data1.sobakasu_N_3rd);

            Cube.GetComponent<Box_roll>().turquoise();
            Cube.GetComponent<Box_roll>().Mode_Change(1);

        }
        else if (Up == 2)
        {
            //hard
            Debug.Log("sobakasu");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(data1.sobakasu_H_1st);
            Debug.Log("1st:" + data1.sobakasu_H_1st);

            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(data1.sobakasu_H_2nd);
            Debug.Log("2st:" + data1.sobakasu_H_2nd);

            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(data1.sobakasu_H_3rd);
            Debug.Log("3st:" + data1.sobakasu_H_3rd);

            Cube.GetComponent<Box_roll>().pink();
            Cube.GetComponent<Box_roll>().Mode_Change(2);
        }
        else
        {
            Debug.Log("error location reset to 0");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(0);
            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(0);
            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(0);

            Cube.GetComponent<Box_roll>().black();
        }

    }
    public void harehare(Data data1)
    {
        //select画面の名前を変更
        SOUND_NAME.GetComponent<SOUND_NAME_C>().ChangeName("ハレ晴レユカイ");
        if (Up == 0)
        {

            //easy
            Debug.Log("harehare");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(data1.harehare_E_1st);
            Debug.Log("1st:" + data1.harehare_E_1st);

            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(data1.harehare_E_2nd);
            Debug.Log("2st:" + data1.harehare_E_2nd);

            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(data1.harehare_E_3rd);
            Debug.Log("3st:" + data1.harehare_E_3rd);

            Cube.GetComponent<Box_roll>().pastel_green();
            Cube.GetComponent<Box_roll>().Mode_Change(0);
        }
        else if (Up == 1)
        {
            //nomal
            Debug.Log("harehare");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(data1.harehare_N_1st);
            Debug.Log("1st:" + data1.harehare_N_1st);

            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(data1.harehare_N_2nd);
            Debug.Log("2st:" + data1.harehare_N_2nd);

            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(data1.harehare_N_3rd);
            Debug.Log("3st:" + data1.harehare_N_3rd);

            Cube.GetComponent<Box_roll>().turquoise();
            Cube.GetComponent<Box_roll>().Mode_Change(1);

        }
        else if (Up == 2)
        {
            //hard
            Debug.Log("harehare");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(data1.harehare_H_1st);
            Debug.Log("1st:" + data1.harehare_H_1st);

            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(data1.harehare_H_2nd);
            Debug.Log("2st:" + data1.harehare_H_2nd);

            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(data1.harehare_H_3rd);
            Debug.Log("3st:" + data1.harehare_H_3rd);

            Cube.GetComponent<Box_roll>().pink();
            Cube.GetComponent<Box_roll>().Mode_Change(2);
        }
        else
        {
            Debug.Log("error location reset to 0");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(0);
            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(0);
            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(0);

            Cube.GetComponent<Box_roll>().black();
        }

    }
    public void connect(Data data1)
    {
        //select画面の名前を変更
        SOUND_NAME.GetComponent<SOUND_NAME_C>().ChangeName("コネクト");
        if (Up == 0)
        {

            //easy
            Debug.Log("harehare");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(data1.connect_E_1st);
            Debug.Log("1st:" + data1.connect_E_1st);

            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(data1.connect_E_2nd);
            Debug.Log("2st:" + data1.harehare_E_2nd);

            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(data1.connect_E_3rd);
            Debug.Log("3st:" + data1.connect_E_3rd);

            Cube.GetComponent<Box_roll>().pastel_green();
            Cube.GetComponent<Box_roll>().Mode_Change(0);
        }
        else if (Up == 1)
        {
            //nomal
            Debug.Log("harehare");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(data1.connect_N_1st);
            Debug.Log("1st:" + data1.connect_N_1st);

            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(data1.connect_N_2nd);
            Debug.Log("2st:" + data1.connect_N_2nd);

            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(data1.connect_N_3rd);
            Debug.Log("3st:" + data1.connect_N_3rd);

            Cube.GetComponent<Box_roll>().turquoise();
            Cube.GetComponent<Box_roll>().Mode_Change(1);

        }
        else if (Up == 2)
        {
            //hard
            Debug.Log("harehare");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(data1.connect_H_1st);
            Debug.Log("1st:" + data1.connect_H_1st);

            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(data1.connect_H_2nd);
            Debug.Log("2st:" + data1.connect_H_2nd);

            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(data1.connect_H_3rd);
            Debug.Log("3st:" + data1.connect_H_3rd);

            Cube.GetComponent<Box_roll>().pink();
            Cube.GetComponent<Box_roll>().Mode_Change(2);
        }
        else
        {
            Debug.Log("error location reset to 0");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(0);
            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(0);
            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(0);

            Cube.GetComponent<Box_roll>().black();
        }

    }
    public void EndMark(Data data1)
    {
        //select画面の名前を変更
        SOUND_NAME.GetComponent<SOUND_NAME_C>().ChangeName("エンドマークに希望と涙を添えて");
        if (Up == 0)
        {

            //easy
            Debug.Log("EndMark");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(data1.EndMark_E_1st);
            Debug.Log("1st:" + data1.EndMark_E_1st);

            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(data1.EndMark_E_2nd);
            Debug.Log("2st:" + data1.EndMark_E_2nd);

            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(data1.EndMark_E_3rd);
            Debug.Log("3st:" + data1.EndMark_E_3rd);

            Cube.GetComponent<Box_roll>().pastel_green();
            Cube.GetComponent<Box_roll>().Mode_Change(0);
        }
        else if (Up == 1)
        {
            //nomal
            Debug.Log("EndMark");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(data1.EndMark_N_1st);
            Debug.Log("1st:" + data1.EndMark_N_1st);

            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(data1.EndMark_N_2nd);
            Debug.Log("2st:" + data1.EndMark_N_2nd);

            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(data1.EndMark_N_3rd);
            Debug.Log("3st:" + data1.EndMark_N_3rd);

            Cube.GetComponent<Box_roll>().turquoise();
            Cube.GetComponent<Box_roll>().Mode_Change(1);
        }
        else if (Up == 2)
        {
            //hard
            Debug.Log("EndMark");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(data1.EndMark_H_1st);
            Debug.Log("1st:" + data1.EndMark_H_1st);

            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(data1.EndMark_H_2nd);
            Debug.Log("2st:" + data1.EndMark_H_2nd);

            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(data1.EndMark_H_3rd);
            Debug.Log("3st:" + data1.EndMark_H_3rd);

            Cube.GetComponent<Box_roll>().pink();
            Cube.GetComponent<Box_roll>().Mode_Change(2);
        }
        else
        {
            Debug.Log("error location reset to 0");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(0);
            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(0);
            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(0);

            Cube.GetComponent<Box_roll>().black();
        }

    }

    public void DoD(Data data1)
    {
        //select画面の名前を変更
        SOUND_NAME.GetComponent<SOUND_NAME_C>().ChangeName("Dead or Die");
        if (Up == 0)
        {

            //easy
            Debug.Log("DoD");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(data1.DoD_E_1st);
            Debug.Log("1st:" + data1.DoD_E_1st);

            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(data1.DoD_E_2nd);
            Debug.Log("2st:" + data1.DoD_E_2nd);

            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(data1.DoD_E_3rd);
            Debug.Log("3st:" + data1.DoD_E_3rd);

            Cube.GetComponent<Box_roll>().pastel_green();
            Cube.GetComponent<Box_roll>().Mode_Change(0);
        }
        else if (Up == 1)
        {
            //nomal
            Debug.Log("DoD");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(data1.DoD_N_1st);
            Debug.Log("1st:" + data1.DoD_N_1st);

            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(data1.DoD_N_2nd);
            Debug.Log("2st:" + data1.DoD_N_2nd);

            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(data1.DoD_N_3rd);
            Debug.Log("3st:" + data1.DoD_N_3rd);

            Cube.GetComponent<Box_roll>().turquoise();
            Cube.GetComponent<Box_roll>().Mode_Change(1);

        }
        else if (Up == 2)
        {
            //hard
            Debug.Log("DoD");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(data1.DoD_H_1st);
            Debug.Log("1st:" + data1.DoD_H_1st);

            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(data1.DoD_H_2nd);
            Debug.Log("2st:" + data1.DoD_H_2nd);

            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(data1.DoD_H_3rd);
            Debug.Log("3st:" + data1.DoD_H_3rd);

            Cube.GetComponent<Box_roll>().pink();
            Cube.GetComponent<Box_roll>().Mode_Change(2);
        }
        else
        {
            Debug.Log("error location reset to 0");
            Text_1st.GetComponent<Text_1st>().ScoreChanger(0);
            Text_2nd.GetComponent<Text_2nd>().ScoreChanger(0);
            Text_3rd.GetComponent<Text_3rd>().ScoreChanger(0);

            Cube.GetComponent<Box_roll>().black();
        }

    }
    //---------------------------------------------------------------------------------------------------------
    /*********************************************************************************************************/
    //スワイプによるマップ変更
    public static int get_up()
    {
        return Up;
    }
    public static int get_Down()
    {
        return Down;
    }
    public static int get_Right()
    {
        return Right;
    }
    public static int get_Left()
    {
        return Left;
    }
    public void Swipe_Left()
    {

        Left++;
        Right--;
        MusicC();
    }
    public void Swipe_Right()
    {

        Right++;
        Left--;
        MusicC();
    }
    public void Swipe_Up()
    {

        Up++;
        Down--;
        MusicC();
    }
    public void Swipe_Down()
    {

        Down++;
        Up--;
        MusicC();
    }
    //

    public void MusicC()
    {


        Data data1 = null;
        data1 = Load("");

        switch (Left)
        {
            case 0:


                if (data1.FD == 1)
                {
                    FD(data1);
                }
                else
                {
                    //入力無視にする　lockedオブジェクト生成

                }
                break;

            case 1:

                if (data1.Charles == 1)
                {
                    Charles(data1);
                }
                else
                {
                    //入力無視にする　lockedオブジェクト生成

                }
                break;

            case 2:

                if (data1.harehare == 1)
                {
                    harehare(data1);
                }
                else
                {
                    //入力無視にする　lockedオブジェクト生成

                }
                break;

            case 3:

                if (data1.connect == 1)
                {
                    connect(data1);
                }
                else
                {
                    //入力無視にする　lockedオブジェクト生成

                }
                break;
            case 4:

                if (data1.sobakasu == 1)
                {
                    sobakasu(data1);
                }
                else
                {
                    //入力無視にする　lockedオブジェクト生成

                }
                break;
                
            case 5:

                if (data1.tooriyo == 1)
                {
                    tooriyo(data1);
                }
                else
                {
                    //入力無視にする　lockedオブジェクト生成

                }
                break;
            case 6:

                if (data1.UMR == 1)
                {
                    UMR(data1);
                }
                else
                {
                    //入力無視にする　lockedオブジェクト生成

                }

                break;
            default:

                Error_location();
                break;
        }
    }
    /*********************************************************************************************************/
    void Update()
    {


        if (flac_Set == 0)
        {
            Data data1 = null;
            data1 = Load("");
            MusicC();
            flac_Set++;
        }

        /*if (Input.GetKeyDown("s"))
        {
            Save();

        }
        if (Input.GetKeyDown("l"))
        {
            Data data1 = null;
            data1 = Load("");
            Debug.Log("Load 実行");
            Debug.Log("1st:" + data1.score_1st);
            Debug.Log("2st:" + data1.score_2st);
            Debug.Log("3st:" + data1.score_3st);

        }
        if (Input.GetKeyDown("f"))
        {
            Data data1 = null;
            data1 = Load("");
            FD(data1);

        }*/
    }

    public Data Map()
    {
        int f = 0;
        string datastr = "";

        try
        {
            reader = new StreamReader(Application.dataPath + "/Resources/Data/Save_Data.json");
            datastr = reader.ReadToEnd();
        }
        catch (FileNotFoundException)
        {
            Debug.Log("ファイルがありません");
        }
        catch (IOException)
        {
            Debug.Log("ファイルオープンエラー");
        }
        finally
        {
            if (reader != null)
            {
                reader.Close();
                f = 1;
            }
        }
        if (f == 1)
        {
            return JsonUtility.FromJson<Data>(datastr);
        }
        else
        {
            return null;
        }
    }
    public Data Load(string sound)
    {
        //Data a = Resources.Load(Save_Data);


        int f = 0;
        string datastr = "";

        try
        {
            reader = new StreamReader(Application.dataPath + "/Resources/Data/Save_Data.json");
            datastr = reader.ReadToEnd();
        }
        catch (FileNotFoundException)
        {
            Debug.Log("ファイルがありません");
        }
        catch (IOException)
        {
            Debug.Log("ファイルオープンエラー");
        }
        finally
        {
            if (reader != null)
            {
                reader.Close();
                f = 1;
            }
        }
        if (f == 1)
        {
            return JsonUtility.FromJson<Data>(datastr);

        }
        else
        {
            return null;
        }

    }
    public void ScoreC()
    {
        int a;

    }
    [Serializable]
    public class Data
    {
        public string USER_Name = "ささづか.py";
        //曲を追加したら上に記述　　　ここ変える
        //string[] Music = new string[3] { "FD", "Evans", "EndMark" };
        /*
        public int _E_1st,_E_2nd,_E_3rd;
        public int _N_1st,_N_2nd,_N_3rd;
        public int _H_1st,_H_2nd,_H_3rd;
        */
        //         全米が泣いた
        public int score_1st;
        public int score_2st;
        public int score_3st;
        //逃げるなささづか
        //いま何時？ささづか
        //もう戻れないあの頃

        //FD
        //曲の取得状況0 or null で未取得　1で取得済み
        public int FD;
        //難易度ごとのスコア
        public int FD_E_1st, FD_E_2nd, FD_E_3rd;
        public int FD_N_1st, FD_N_2nd, FD_N_3rd;
        public int FD_H_1st, FD_H_2nd, FD_H_3rd;
        //Charles
        public int Charles;
        public int Charles_E_1st, Charles_E_2nd, Charles_E_3rd;
        public int Charles_N_1st, Charles_N_2nd, Charles_N_3rd;
        public int Charles_H_1st, Charles_H_2nd, Charles_H_3rd;
        //harehare
        public int harehare;
        public int harehare_E_1st, harehare_E_2nd, harehare_E_3rd;
        public int harehare_N_1st, harehare_N_2nd, harehare_N_3rd;
        public int harehare_H_1st, harehare_H_2nd, harehare_H_3rd;
        //UMR
        public int UMR;
        public int UMR_E_1st, UMR_E_2nd, UMR_E_3rd;
        public int UMR_N_1st, UMR_N_2nd, UMR_N_3rd;
        public int UMR_H_1st, UMR_H_2nd, UMR_H_3rd;
        //connect
        public int connect;
        public int connect_E_1st, connect_E_2nd, connect_E_3rd;
        public int connect_N_1st, connect_N_2nd, connect_N_3rd;
        public int connect_H_1st, connect_H_2nd, connect_H_3rd;
        //sobakasu
        public int sobakasu;
        public int sobakasu_E_1st, sobakasu_E_2nd, sobakasu_E_3rd;
        public int sobakasu_N_1st, sobakasu_N_2nd, sobakasu_N_3rd;
        public int sobakasu_H_1st, sobakasu_H_2nd, sobakasu_H_3rd;
        //tooriyo
        public int tooriyo;
        public int tooriyo_E_1st, tooriyo_E_2nd, tooriyo_E_3rd;
        public int tooriyo_N_1st, tooriyo_N_2nd, tooriyo_N_3rd;
        public int tooriyo_H_1st, tooriyo_H_2nd, tooriyo_H_3rd;
        //Evans
        public int Evans;
        public int Evans_E_1st, Evans_E_2nd, Evans_E_3rd;
        public int Evans_N_1st, Evans_N_2nd, Evans_N_3rd;
        public int Evans_H_1st, Evans_H_2nd, Evans_H_3rd;

        //EndMark
        public int EndMark;
        public int EndMark_E_1st, EndMark_E_2nd, EndMark_E_3rd;
        public int EndMark_N_1st, EndMark_N_2nd, EndMark_N_3rd;
        public int EndMark_H_1st, EndMark_H_2nd, EndMark_H_3rd;

        //Dead_or_Die
        public int DoD;
        public int DoD_E_1st, DoD_E_2nd, DoD_E_3rd;
        public int DoD_N_1st, DoD_N_2nd, DoD_N_3rd;
        public int DoD_H_1st, DoD_H_2nd, DoD_H_3rd;

        //Doppelganger
        public int Doppel;
        public int Doppel_E_1st, Doppel_E_2nd, Doppel_E_3rd;
        public int Doppel_N_1st, Doppel_N_2nd, Doppel_N_3rd;
        public int Doppel_H_1st, Doppel_H_2nd, Doppel_H_3rd;

        //初音ミク_激唱
        public int MikuGeki;
        public int MikuGeki_E_1st, MikuGeki_E_2nd, MikuGeki_E_3rd;
        public int MikuGeki_N_1st, MikuGeki_N_2nd, MikuGeki_N_3rd;
        public int MikuGeki_H_1st, MikuGeki_H_2nd, MikuGeki_H_3rd;

        //初音ミク_消失
        public int MikuShou;
        public int MikuShou_E_1st, MikuShou_E_2nd, MikuShou_E_3rd;
        public int MikuShou_N_1st, MikuShou_N_2nd, MikuShou_N_3rd;
        public int MikuShou_H_1st, MikuShou_H_2nd, MikuShou_H_3rd;

        //初音ミク_消失_劇場版
        public int MikuShouGeki;
        public int MikuShouGeki_E_1st, MikuShouGeki_E_2nd, MikuShouGeki_E_3rd;
        public int MikuShouGeki_N_1st, MikuShouGeki_N_2nd, MikuShouGeki_N_3rd;
        public int MikuShouGeki_H_1st, MikuShouGeki_H_2nd, MikuShouGeki_H_3rd;

        //PUPA
        public int PUPA;
        public int PUPA_E_1st, PUPA_E_2nd, PUPA_E_3rd;
        public int PUPA_N_1st, PUPA_N_2nd, PUPA_N_3rd;
        public int PUPA_H_1st, PUPA_H_2nd, PUPA_H_3rd;

        //void_setup
        public int vs;
        public int vs_E_1st, vs_E_2nd, vs_E_3rd;
        public int vs_N_1st, vs_N_2nd, vs_N_3rd;
        public int vs_H_1st, vs_H_2nd, vs_H_3rd;

        /*
        //仙狐さんモフりたい
        //今宵mofumofu!!
        public int Koyoi_E_1st, Koyoi_E_2nd, Koyoi_E_3rd;
        public int Koyoi_N_1st, Koyoi_N_2nd, Koyoi_N_3rd;
        public int Koyoi_H_1st, Koyoi_H_2nd, Koyoi_H_3rd;

        //もっふもっふDEよいのじゃよ
        public int MFMF_E_1st,MFMF_E_2nd,MFMF_E_3rd;
        public int MFMF_N_1st,MFMF_N_2nd,MFMF_N_3rd;
        public int MFMF_H_1st,MFMF_H_2nd,MFMF_H_3rd;
        */
    }

}

