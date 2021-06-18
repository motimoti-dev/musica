using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Save_Load : MonoBehaviour
{
    
    StreamWriter writer;
    StreamReader reader;
    public void Save()
    {
        //曲数いれて[ここ]

        string[] Music = new string[] { "FD", "Evans", "EndMark","DoD", "Doppel", "MikuGeki", "MikuShou",
                                        "MikuShouGeki" ,"PUPA","vs"};
        int Songs;
        Songs = Music.Length;
        Debug.Log("Save実行 曲数"+Songs);
       
        try
        {
            Data data = new Data();

            writer = new StreamWriter(Application.dataPath + "/Save/Save_Data.json",false);
            //for()
            data.score_1st = 1000000;
            data.score_2st = 900000;
            data.score_3st = 800000;
            string jsonstr = JsonUtility.ToJson(data);
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
                writer.Close();
            }
        }
    }
    public Data Load()
    {
        int f = 0;
        string datastr = "";
        
        try
        {
            reader = new StreamReader(Application.dataPath + "/Save/Save_Data.json");
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
    private void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            Save();
        }
        if (Input.GetKeyDown("l"))
        {
            Data data1 = null;
            data1 = Load();
            Debug.Log("1st:" + data1.score_1st);
            Debug.Log("2st:" + data1.score_2st);
            Debug.Log("3st:" + data1.score_3st);
        }
    }
}
[Serializable]
public class Data
{
    public string USER_Name;
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
    public int FD_E_1st,FD_E_2nd,FD_E_3rd;
    public int FD_N_1st,FD_N_2nd,FD_N_3rd;
    public int FD_H_1st,FD_H_2nd,FD_H_3rd;

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