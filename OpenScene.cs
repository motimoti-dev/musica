using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScene : MonoBehaviour
{
    [Header("開きたいシーン")] public string NAME;

    private void OnMouseDown()
    {
    SceneManager.LoadScene(NAME);
    }
}
