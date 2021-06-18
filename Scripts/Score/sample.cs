using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sample : MonoBehaviour {

    public GameObject note;
    private AudioSource audioSource;
    public AudioClip Clip1;
    int a, i, j = 4, max = 100;

    void Start()
    {
        for (i = 1; i <= max; i++)
        {
            a = Random.Range(-3, 3);
            Debug.Log(a);
            Instantiate(note, new Vector3(a * 2, j, 0), transform.rotation);
            
            j = j + 6;
        }
    }

}
