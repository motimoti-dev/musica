using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class scoreC : MonoBehaviour
{
    static int score = 0,
               cc = 0,
               mc = 0,
               hit = 0,
               smax, shows = 0,
               zeroid, pers, sa = 0,
               amount = 0,
               combo = 0,
               maxc = 0,
               maxcombo = 0;
    double percent;
    public int AllCombo = 0;
    string[] zero = { null, "0", "00", "000", "0000", "00000", "000000", "0000000" };
    public GameObject score_object = null;
    public GameObject combo_object = null;
    public static string NAME;
    public string AudioName = "";
    public string Data_sound;
    public static string NAME_SOUND;
    private int c, combob = 0;
    GameObject play;
    void Start()
    {
        NAME = AudioName;
        //ここにはデータ上の名前を使う
        NAME_SOUND = Data_sound;
        score = 0;
        cc = 0;
        mc = 0;
        hit = 0;
        smax = shows = 0;
        zeroid = pers = sa = 0;
        combo = 0;
        maxc = 0;
        maxcombo = 0;
        amount = AllCombo;
        int a = Camera.main.GetComponent<Object_Relay>().Get_PlayC().GetComponent<PlayC>().Combo_Max();
        if (a != 0)
        {
            amount = AllCombo = a;
        }
        for (c = 1; c <= amount; c++)
        {
            combob += c;
        }
        smax = amount * 1000;
        smax += combob;
        score_object.transform.position = new Vector2(800 / 1000.0f * Screen.width, 900 / 1000.0f * Screen.height);
        combo_object.transform.position = new Vector2(800 / 1000.0f * Screen.width, 800 / 1000.0f * Screen.height);
        score_object.GetComponent<Text>().fontSize = Convert.ToInt32(Screen.width * 45 / 1000.0f);
        combo_object.GetComponent<Text>().fontSize = Convert.ToInt32(Screen.width * 45 / 1000.0f);
    }
    public void Set_Sound(string Sound)
    {
        NAME = AudioName = Sound;
    }
    public void Set_Data(string Data)
    {
        NAME_SOUND = Data_sound = Data;
    }
    public void Critical()
    {
        cc++;
        combo++;
        score += combo + 1000;
        maxcc();
    }
    public void Hit()
    {
        hit++;
        combo++;
        score += combo + 100;
        maxcc();
    }
    public void Miss()
    {
        mc++;
        combo = 0;
    }
    private void scoreS()
    {
        percent = (double)score / (double)smax;
        percent = percent * 1000000;
        pers = (int)percent;
    }
    void Update()
    {
        score_object.GetComponent<RectTransform>().sizeDelta = new Vector2(score_object.GetComponent<Text>().preferredWidth, score_object.GetComponent<Text>().preferredHeight);
        combo_object.GetComponent<RectTransform>().sizeDelta = new Vector2(combo_object.GetComponent<Text>().preferredWidth, combo_object.GetComponent<Text>().preferredHeight);
        scoreS();
        add();
        zeroset();
        Text score_text = score_object.GetComponent<Text>();
        score_text.text = "Score: " + zero[zeroid] + shows;
        Text combo_text = combo_object.GetComponent<Text>();
        combo_text.text = "Combo: " + combo;
        //maxcomboを比較&代入
        if (combo >= maxcombo) { maxcombo = combo; }
    }
    private void zeroset()
    {
        if (shows == 0)
        {
            zeroid = 6;
        }
        else if (shows <= 99)
        {
            zeroid = 5;
        }
        else if (shows <= 999)
        {
            zeroid = 4;
        }
        else if (shows <= 9999)
        {
            zeroid = 3;
        }
        else if (shows <= 99999)
        {
            zeroid = 2;
        }
        else if (shows <= 999999)
        {
            zeroid = 1;
        }
        else
        {
            zeroid = 0;
        }
    }
    private void add()
    {
        if (pers > shows)
        {
            sa = pers - shows;
            if (sa >= 111111)
            {
                shows += 111111;
            }
            else if (sa >= 11111)
            {
                shows += 11111;
            }
            else if (sa >= 1111)
            {
                shows += 1111;
            }
            else if (sa >= 111)
            {
                shows += 111;
            }
            else if (sa >= 11)
            {
                shows += 11;
            }
            else
            {
                shows++;
            }
        }
    }
    private void maxcc()
    {
        if (combo < maxc)
        {
            maxc = combo;
        }
    }

    //数値を ResultC に渡す
    public static int GetMaxCombo()
    {
        return maxcombo;
    }
    public static int GetCH()
    {
        return cc;
    }
    public static int GetHIT()
    {
        return hit;
    }
    public static int GetMISS()
    {
        return mc;
    }
    public static int GetSCORE()
    {
        return shows;
    }
    public static string GetNAME()
    {
        return NAME;
    }
    public static string GetSOUND()
    {
        return NAME_SOUND;
    }
}