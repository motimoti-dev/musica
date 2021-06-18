using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Easing : MonoBehaviour {

    int flac_start = 0;
	void Start () {
        /*this.GetComponent<Transform>().DOMoveX(15.0f, 3.0f)
        .SetEase(Ease.InElastic);*///振動Linear平行移動
        
    }

    private void Update()
    {
        if (flac_start == 1) {
            flac_start++;
            this.GetComponent<Transform>().DOMoveX(16f, 1.5f)
            .SetEase(Ease.Linear);

        }
    }
    public void flacplus()
    {
        flac_start = 1;
    }
}
