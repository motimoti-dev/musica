using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_roll : MonoBehaviour {

    // Use this for initialization
    public int Mode = 0;
	float speed = 0.05f;
    float Defaultspeed = 0.7f;
    public float addspeed = 0;
    public int turn = 0;

    public void Mode_C(int a) {

        Mode = a;
        
    }
    
    void Update()
    {
        if (Mode == 0)
        {
            transform.Rotate(new Vector3(0.025f, 0.025f, Defaultspeed));
   

        }
        if (Mode == 1)
        {
            transform.Rotate(new Vector3(-0.02f, -0.02f, -Defaultspeed));
            transform.Rotate(new Vector3(-0.02f, -0.02f, -Defaultspeed));
            turn++;
            turn++;
            if (turn == 20)
            {
                turn = 0;
                Mode--;
            }
        }
        if (Mode == 2)
        {

            transform.Rotate(new Vector3(0, 0, Defaultspeed + addspeed));
            if (addspeed <= 10)
                addspeed += speed;
        }

        if (Mode == 3)
        {

            transform.Rotate(new Vector3(0, 0, Defaultspeed + addspeed));
            if (addspeed >= 0)
                addspeed -= speed;
        }

        if (Mode == 4)
        {
            
            transform.Rotate(new Vector3(0, 0, -Defaultspeed - addspeed));
            if (addspeed <= 10)
                addspeed += speed;
        }

        if (Mode == 5)
        {

            transform.Rotate(new Vector3(0, 0, -Defaultspeed - addspeed));
            if (addspeed >= 0)
                addspeed -= speed;
        }


        //Vector3 pos = (GameObject.Find("Boader_Cube")).GetComponent<Renderer>().bounds.center;

    }
}
