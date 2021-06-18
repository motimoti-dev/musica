using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartC : MonoBehaviour {
    GameObject text;
    GameObject a, b, c;
    private AudioSource audioSource;
    void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.Play();
    }

    void OnMouseDown()
    {
        Debug.Log("clicked!");
        text = GameObject.Find("Text");
        a = GameObject.Find("black wall");
        b = GameObject.Find("ice wall");
        c = GameObject.Find("Logo");

        text.GetComponent<Start_T>().fade();
        a.GetComponent<Easing>().flacplus();
        b.GetComponent<Easing_l>().flacplus();
        c.GetComponent<Easing_logo>().flacplus();
        Invoke("Scene_Load",3f);
    }
    void Scene_Load() {
        SceneManager.LoadScene("selecter");
    }
    void Update()
    {
        if (Input.anyKeyDown)
        {
            OnMouseDown();
        }
    }
}
