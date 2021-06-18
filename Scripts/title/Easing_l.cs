using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Easing_l : MonoBehaviour {
    int flac_start = 0;
    public float a=0;
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (flac_start == 1) {
            flac_start++;
            while (a < 0.5f)
            {
                a += Time.deltaTime;
            }
            this.GetComponent<Transform>().DOMoveX(16f, 1f)
            .SetEase(Ease.InExpo);
        }
    }
    public void flacplus()
    {
        flac_start = 1;
    }
}
