#if UNITY_ENGINE
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) End();
    }
    public void End()
    {
        bool EndQuest = UnityEditor.EditorUtility.DisplayDialog("Musica", "ゲームを終了しますか?", "はい", "いいえ");
        if (EndQuest)
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }
}
#endif