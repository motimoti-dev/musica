using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;


public class Load_Map_advance : MonoBehaviour {


    public static int Left = 0, Right = 0, Up = 0, Down = 0;

    public void Start()
    {
        Transform Transform = Camera.main.transform;
        Vector3 Pos = Transform.position;
        if (Up != 0)
        {
            int addp = 0;
            addp = Up * 10;
            Pos.y = addp;
        }
        if (Right != 0) {
            int addp = 0;
            addp = Right * -18;
            Pos.x = addp;
        }
        Transform.position = Pos;
        //Camera.main.transform.position.x = 
    }
    public void Swipe_Left()
    {

        Left++;
        Right--;
    }
    public void Swipe_Right()
    {

        Right++;
        Left--;
    }
    public void Swipe_Up()
    {

        Up++;
        Down--;
    }
    public void Swipe_Down()
    {
        Down++;
        Up--;
    }
    //

}


