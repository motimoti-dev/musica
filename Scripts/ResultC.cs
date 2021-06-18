using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultC : MonoBehaviour
{
    int score, combo, cc, hit, fast, good, miss, zeroid;
    public GameObject scoretxt = null, scoretxt1 = null, combotxt = null, combotxt1 = null, criticalhittxt = null, criticalhittxt1 = null, hittxt = null, hittxt1 = null, misstxt = null, misstxt1 = null, ranktxt = null, ranktxt1 = null, fctxt = null, fctxt1 = null, nametxt = null, nametxt1 = null;
    string[] zero = { null, "0", "00", "000", "0000", "00000", "000000", "0000000" };
    void Start()
    {
        cc = scoreC.GetCH();
        hit = scoreC.GetHIT();
        miss = scoreC.GetMISS();
        score = scoreC.GetSCORE();
        combo = scoreC.GetMaxCombo();
        zeroset();
        Text name_text = nametxt.GetComponent<Text>();
        Text name_text1 = nametxt1.GetComponent<Text>();
        name_text.text = scoreC.GetNAME();
        name_text1.text = scoreC.GetNAME();
        Text rank_text = ranktxt.GetComponent<Text>();
        Text rank_text1 = ranktxt1.GetComponent<Text>();
        if (score == 1000000)
        {
            rank_text.text = "SSD";
            rank_text1.text = "SSD";
            rank_text.color = new Color32(255, 180, 0, 255);
        }
        else if (score >= 950000)
        {
            rank_text.text = "SS";
            rank_text1.text = "SS";
            rank_text.color = new Color32(255, 180, 104, 255);
        }
        else if (score >= 900000)
        {
            rank_text.text = "S";
            rank_text1.text = "S";
            rank_text.color = new Color32(255, 180, 0, 255);
        }
        else if (score >= 800000)
        {
            rank_text.text = "A";
            rank_text1.text = "A";
            rank_text.color = new Color32(107, 188, 104, 255);
        }
        else if (score >= 700000)
        {
            rank_text.text = "B";
            rank_text1.text = "B";
            rank_text.color = new Color32(101, 221, 205, 255);
        }
        else if (score >= 600000)
        {
            rank_text.text = "C";
            rank_text1.text = "C";
            rank_text.color = new Color32(7, 179, 239, 255);
        }
        else if (score >= 500000)
        {
            rank_text.text = "D";
            rank_text1.text = "D";
            rank_text.color = new Color32(9, 102, 255, 255);
        }
        else if (score >= 400000)
        {
            rank_text.text = "E";
            rank_text1.text = "E";
            rank_text.color = new Color32(248, 70, 234, 255);
        }
        else
        {
            rank_text.text = "F";
            rank_text1.text = "F";
            rank_text.color = new Color32(215, 11, 11, 255);
            rank_text1.color = new Color32(0, 0, 0, 255);
        }
        Text fc_text = fctxt.GetComponent<Text>();
        Text fc_text1 = fctxt1.GetComponent<Text>();
        if (score == 1000000)
        {
            fc_text.text = "ALL CRITICAL";
            fc_text1.text = "ALL CRITICAL";
            fc_text.color = new Color32(255, 180, 0, 255);
        }
        else if (miss == 0)
        {
            fc_text.text = "FULL COMBO";
            fc_text1.text = "FULL COMBO";
            fc_text.color = new Color32(255, 180, 0, 255);
        }
        else
        {
            fc_text.text = null;
            fc_text1.text = null;
        }
        Text score_text = scoretxt.GetComponent<Text>();
        Text score_text1 = scoretxt1.GetComponent<Text>();
        score_text.text = "Score: " + zero[zeroid] + score;
        score_text1.text = "Score: " + zero[zeroid] + score;
        Text combo_text = combotxt.GetComponent<Text>();
        Text combo_text1 = combotxt1.GetComponent<Text>();
        combo_text.text = "MAX Combo: " + combo;
        combo_text1.text = "MAX Combo: " + combo;
        Text ch_text = criticalhittxt.GetComponent<Text>();
        Text ch_text1 = criticalhittxt1.GetComponent<Text>();
        ch_text.text = "CriticalHit: " + cc;
        ch_text1.text = "CriticalHit: " + cc;
        Text hit_text = hittxt.GetComponent<Text>();
        Text hit_text1 = hittxt1.GetComponent<Text>();
        hit_text.text = "Hit: " + hit;
        hit_text1.text = "Hit: " + hit;
        Text miss_text = misstxt.GetComponent<Text>();
        Text miss_text1 = misstxt1.GetComponent<Text>();
        miss_text.text = "Miss: " + miss;
        miss_text1.text = "Miss: " + miss;
    }
    private void zeroset()
    {
        if (score == 0)
        {
            zeroid = 6;
        }
        else if (score <= 99)
        {
            zeroid = 5;
        }
        else if (score <= 999)
        {
            zeroid = 4;
        }
        else if (score <= 9999)
        {
            zeroid = 3;
        }
        else if (score <= 99999)
        {
            zeroid = 2;
        }
        else if (score <= 999999)
        {
            zeroid = 1;
        }
        else
        {
            zeroid = 0;
        }
    }
    public void fanc_menu()
    {
        //セーブするから飛ばない
        string st = Swipe.Get_Scene_Name();
        if (st == null)
        {
            st = "selecter";
        }
        SceneManager.LoadScene(st);
    }
    void Update()
    {
        if (Input.GetKeyDown("j"))
        {
            fanc_menu();
        }
    }
}
