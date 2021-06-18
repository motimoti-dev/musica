using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEC : MonoBehaviour {

    AudioSource audioSource;
    public AudioClip Clip1;
    float Fade;
    void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(Clip1);
        Fade = Time.time+2f;
    }
	
	// Update is called once per frame
	void Update () {
 
        if(Time.time >= Fade) {
            Destroy(this.gameObject);
        }
	}
}
