using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour {
    public GameObject Next;
    public float Time_End = 1.0f;
    public bool End = false;
    public float fade = 1;
    private int mode = 0;
    private float Time_c = 0.0f;
    private Color color32;
    private float n;
    public float Delay = 0.0f;
    private void Start()
    {
        color32 = GetComponent<SpriteRenderer>().color;
        color32.a = 0;
        GetComponent<SpriteRenderer>().color = color32;
        n = 1.0f / fade;
    }
    void Update()
    {
        if (Input.anyKey || Input.GetMouseButtonDown(0))
        {
            if (!End)
            {
                mode = 3;
            }
        }
        Time_c += Time.deltaTime;
        if (color32.a > 1.0f && mode == 1)
        {
            mode = 2;
            Time_c = 0.0f;
        }
        else if (color32.a < 0.0f && mode == 3 && !End)
        {
            Instantiate(Next);
            Destroy(gameObject);
        }
        else if (mode == 3 && End)
        {
            SceneManager.LoadScene("Main");
        }
        else if (mode == 2 && Time_c > Time_End - 2.0f * fade && !End)
        {
            mode = 3;
            Time_c = 0.0f;
        }
        else if (mode == 2 && Time_c > Time_End - 1.0f * fade && End)
        {
            mode = 3;
            Time_c = 0.0f;
        }
        else if (mode == 1)
        {
            color32.a = n * Time_c;
            GetComponent<SpriteRenderer>().color = color32;
        }
        else if (mode == 3 && !End)
        {
            color32.a = 1.0f - (n * Time_c);
            GetComponent<SpriteRenderer>().color = color32;
        }
        else if (mode == 0 && Time_c > Delay)
        {
            mode = 1;
            Time_c = 0.0f;
        }
    }
}