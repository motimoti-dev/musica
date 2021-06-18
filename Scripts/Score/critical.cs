using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class critical : MonoBehaviour {
    float fade;
    GameObject scorec;
    public GameObject Relay_Object;
    void Start()
    {
        fade =Time.time+ 0.2f;
        scorec = Relay_Object.GetComponent<Object_Relay>().Get_ScoreManager();
        scorec.GetComponent<scoreC>().Critical();
    }
    
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 100), "critical");
    }
    void Update()
    {
        if (fade<=Time.time) {
            Destroy(this.gameObject);
        }
    }
}
