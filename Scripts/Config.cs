using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour {

    static public float BGMVolume, SEVolume;
    void Start()
    {
        //シーン遷移しても消されない
        DontDestroyOnLoad(this);
    }

    
    private void Update()
    {
        BGMVolume = PauseC.getBGMVolume();

        SEVolume = PauseC.getSEVolume();
    }



}
