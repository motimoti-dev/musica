using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;



public class Saver : MonoBehaviour {

    StreamWriter writer;
    StreamReader reader;
    int score;
    string name_sound;

    

    void Start() {
        score = scoreC.GetSCORE();
        name_sound = scoreC.GetSOUND();
        Invoke("Assigner", 0.2f);
    }

    void Update() {

    }
    public void Assigner() {

        //
        
        switch (name_sound) {

            case "FD":
                FD();
                break;
            default:
                //データネーム入力してきてね
                //楽曲シーンのscoremanagerの未入力のとこ
                Debug.Log("これダブルクリックして飛んで");
                break;
        }
    }
    public void FD()
    {
        int stack1, stack2;
        Data data;
        data = Load("");
        if (data.FD_E_1st <= score) {
            stack1 = data.FD_E_1st;
            stack2 = data.FD_E_2nd;
            data.FD_E_1st = score;
            data.FD_E_2nd = stack1;
            data.FD_E_3rd = stack2;
            
        } else if (data.FD_E_2nd <= score) {
            stack1 = data.FD_E_2nd;
            data.FD_E_2nd = score;
            data.FD_E_3rd = stack1;

        } else if (data.FD_E_3rd <= score) {
            data.FD_E_3rd = score;
        } else {
            Debug.Log("スコア更新なし");
        }
        Save(data);
    }
    public void Save(Data data)
    {

        Debug.Log("save");

        try
        {


            writer = new StreamWriter(Application.dataPath + "/Save/Save_Data.json", false);
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
                Debug.Log("Close");
                writer.Close();
            }
        }
        Debug.Log("セーブ終了");
    }

    public Data Load(string sound)
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
}
