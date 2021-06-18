using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class PauseC : MonoBehaviour
{
    static public float SongSliderValue, SESliderValue;
    GameObject music_object, snd_SE;
    AudioSource testplay;
    private GUIStyle style01, style02, style03;

    void Start()
    {
        if (SongSliderValue <= 0) SongSliderValue = 1;
        if (SESliderValue <= 0) SESliderValue = 1;
        snd_SE = Camera.main.gameObject;
        music_object = snd_SE.GetComponent<Object_Relay>().Get_PlayC();
        testplay = snd_SE.GetComponent<AudioSource>();
    }
    void OnGUI()
    {
        style01 = new GUIStyle();
        style01.normal.textColor = Color.white;
        style01.fontSize = Convert.ToInt32(Screen.width * 20.0f / 1000.0f);
        style02 = style03 = new GUIStyle(GUI.skin.button);
        style02.normal.textColor = Color.white;
        style02.fontSize = Convert.ToInt32(Screen.width * 40.0f / 1000.0f);
        style03.normal.textColor = Color.white;
        style03.fontSize = Convert.ToInt32(Screen.width * 35.0f / 1000.0f);
        //ウィンドウの基礎
        GUI.Box(new Rect(Screen.width / 600.0f, Screen.height / 1000.0f, Screen.width, Screen.height), "");
        //ウィンドウの非表示のテキスト表示及びボタン
        GUI.Label(new Rect(Screen.width * 75.0f / 100.0f, Screen.height * 3.5f / 100.0f, Screen.width / 2.0f, Screen.width / 30.0f), "ウィンドウの非表示", style01);
        if (GUI.Button(new Rect(Screen.width * 93.0f / 100.0f, Screen.height / 90.0f, Screen.width / 20.0f, Screen.width / 20.0f), "✖", style02))
        {
            this.gameObject.SetActive(false);
        }
        //[最初からやり直す]のボタン
        if (GUI.Button(new Rect(Screen.width * 38.0f / 100.0f, Screen.height * 70.0f / 100.0f, Screen.width / 15.0f, Screen.width / 15.0f), "◀| ", style02))
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        //[曲選択に戻る]のボタン
        if (GUI.Button(new Rect(Screen.width / 2.15f, Screen.height * 70.0f / 100.0f, Screen.width / 15.0f, Screen.width / 15.0f), "■", style02))
        {
            Time.timeScale = 1.0f;
            string st = Swipe.Get_Scene_Name();
            if (st == null)
            {
                st = "selecter";
            }
            SceneManager.LoadScene(st);
        }
        //[タイトルに戻る]のボタン
        if (GUI.Button(new Rect(Screen.width * 55.0f / 100.0f, Screen.height * 70.0f / 100.0f, Screen.width / 15.0f, Screen.width / 15.0f), "title", style03))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Main");
        }

        //BackGroundMusicの音量調整
        SongSliderValue = GUI.HorizontalSlider(new Rect(Screen.width / 2.65f, Screen.height / 2.11f, Screen.width / 4.0f, Screen.height / 20.0f), SongSliderValue, 0.0f, 1.0f);
        //BGMテキスト表示
        GUI.Label(new Rect(Screen.width / 1.57f, Screen.height / 2.15f, Screen.width / 2.0f, Screen.width / 30.0f), "BGMvalue:" + SongSliderValue * 100, style01);
        music_object.GetComponent<AudioSource>().volume = SongSliderValue;

        //SoundEffectの音量調整
        SESliderValue = GUI.HorizontalSlider(new Rect(Screen.width / 2.65f, Screen.height / 1.75f, Screen.width / 4.0f, Screen.height / 20.0f), SESliderValue, 0.0f, 1.0f);
        //SEテキスト表示
        GUI.Label(new Rect(Screen.width / 1.57f, Screen.height / 1.78f, Screen.width / 2.0f, Screen.width / 30.0f), "SEvalue:" + SESliderValue * 100, style01);
        snd_SE.GetComponent<AudioSource>().volume = SESliderValue;
        //SEの音量確認
        if (GUI.Button(new Rect(Screen.width * 33.0f / 100.0f, Screen.height / 1.8f, Screen.width / 30.0f, Screen.width / 30.0f), "♪", style03))
        {
            testplay.PlayOneShot(testplay.clip);
        }
    }
    public static float getBGMVolume()
    {
        return SongSliderValue;
    }

    public static float getSEVolume()
    {
        return SESliderValue;
    }
}