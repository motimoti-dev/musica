using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreC_Gloria : MonoBehaviour {

    int score = 0, cc = 0, mc = 0, hit = 0, smax, shows = 0, zeroid, pers, sa, fc = 0;
    double percent;
    string[] zero = { null, "0", "00", "000", "0000", "00000", "000000", "0000000" };
    public GameObject score_object = null;
    GameObject play;
    void Start()
    {
        play = GameObject.Find("MusicPlay");
        smax = play.GetComponent<GloriaPlay>().ncount();
        smax = smax * 100;
    }

    public void Critical()
    {
        score = score + 100;
        cc++;
    }
    public void Hit()
    {
        score = score + 10;
        hit++;
    }
    public void faster()
    {
        fc++;
    }
    public void Miss()
    {
        mc++;
    }
    private void scoreS()
    {
        percent = (double)score / (double)smax;
        percent = percent * 1000000;
        pers = (int)percent;
    }
    void Update()
    {
        scoreS();
        add();
        zeroset();
        Text score_text = score_object.GetComponent<Text>();
        score_text.text = "Score: " + zero[zeroid] + shows;
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
            if (sa >= 1000)
            {
                shows = shows + 1000;
            }
            else if (sa >= 500)
            {
                shows = shows + 500;
            }
            else if (sa >= 300)
            {
                shows = shows + 300;
            }
            else if (sa >= 100)
            {
                shows = shows + 100;
            }
            else if (sa >= 50)
            {
                shows = shows + 50;
            }
            else if (sa >= 25)
            {
                shows = shows + 25;
            }
            else if (sa >= 10)
            {
                shows = shows + 10;
            }
            else if (sa >= 5)
            {
                shows = shows + 5;
            }
            else if (sa >= 3)
            {
                shows = shows + 3;
            }
            else
            {
                shows++;
            }
        }
    }
}
