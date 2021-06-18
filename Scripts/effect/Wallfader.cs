using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallfader : MonoBehaviour
{
    float fade, time_t;
    void Start()
    {
        if (Auto_Mode_Set.Get_Auto())
        {
            fade = 0.15f;
        }
        else
        {
            fade = 0.05f;
        }
    }

    void Update()
    {
        if (fade <= time_t)
        {
            Destroy(this.gameObject);
        }
        time_t += Time.deltaTime;
    }
}
