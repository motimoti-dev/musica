using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveC : MonoBehaviour
{
    private GameObject test;
    private int f = 0;
    void Start()
    {
        test = GameObject.Find("ScoreManager");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (f == 0)
            {
                Debug.Log("false");
                f = 1;
                test.GetComponent<test>().enabled = false;
            }
            else
            {
                Debug.Log("true");
                f = 0;
                test.GetComponent<test>().enabled = true;
            }
        }
    }
}