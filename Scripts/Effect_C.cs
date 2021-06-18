using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_C : MonoBehaviour {
    public void Effect_Relay(int Lane,int type)
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name == "" + Lane)
            {
                transform.GetChild(i).GetComponent<Effect_OutPut>().Effect_Out_Put(type);
            }
        }
    }
}