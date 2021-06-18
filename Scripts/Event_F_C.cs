using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_F_C : MonoBehaviour {
    public bool Flag = true;
    public bool Get_F()
    {
        return Flag;
    }
    public void Set_F(bool a)
    {
        Flag = a;
    }
    private void Start()
    {
        Flag = true;
    }
}
