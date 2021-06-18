using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GloriaPlay : MonoBehaviour {
    public AudioClip Clip1;
    private AudioSource audioSource;
    //private float px, py;
    public GameObject GameObject;

    //public float spa, spb, spc;
    public float timet;
    private int Endc = 0;
    //timet 3f
    private int a, b = 0,c,count=0;
    //次の秒数,ぱらめーた,
    private float[] Gakufu = new float[] {
        1f,-9f,//から音楽

        3f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        1f,1f,
        -10,-1
                 };


    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = Clip1;
        //Thread.Sleep(3000);
        //yield return new WaitForSeconds(2);
        //for (;timet >= Time.time ; ) {
        //}
        //audioSource.Play();

    }


    void Update()
    {
    aout:
        if (Time.time >= timet && Endc == 0)
        {
            if (Gakufu[b] == -10)
            {
                Endc -= 1;
                goto aout;
            }
            if (Gakufu[b + 1] == -9)
            {
                audioSource.Play();
            }
            b += 2;
            timet += Gakufu[b];
            if (Gakufu[b - 1] != -1 && Gakufu[b - 1] != -9)
            {

                Fanc01();
            }


        }

        //Debug.Log(Time.time);
    }

    void Fanc01()
    {
        a = Random.Range(-3, 3);
        //(int)Gakufu[b-1]
        //a = 1;
        //Debug.Log(a);
        Instantiate(GameObject, new Vector3(a * 2, 4f, 0), transform.rotation);
    }
    public int ncount()
    {
        for (c = 3; Gakufu[c] != -1; c = c + 2)
        {
            count++;
        }
        return count;
    }
}
