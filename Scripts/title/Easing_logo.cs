using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Easing_logo : MonoBehaviour {
    public float a,b = 0;
    int flac = 0;
    int flac_start;

	void Update () {
        if (flac_start == 1)
        {
            
            Transform transform = this.transform;
            //ワールド座標をもとに回転を取得
            Vector3 roll = transform.eulerAngles;
            Vector3 pos = transform.position;
            if (flac == 0)
                transform.Translate(-0.08f, 0.13f, 0);
            if (roll.z < 90)
            {
                roll.z += 0.8f;
            }
            else
            {
                flac = 1;
            }
            if (roll.z < 90)
                roll.z += 0.8f;
            if (flac == 1)
            {
                flac++;
                flac_start++;
                this.GetComponent<Transform>().DOMoveX(-16f, 1f)
                .SetEase(Ease.Linear);
            }
            //roll(回転)を設定
            transform.eulerAngles = roll;
        }
    }

    public void flacplus() {
        flac_start = 1;
    }
}
