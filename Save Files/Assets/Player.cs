using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : CharacterGUID
{
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            NewBehaviourScript.Save("Cody", new GameData());
        }


        if (Input.GetKeyDown(KeyCode.L))
        {
            GameData gd = NewBehaviourScript.Load("Cody");
            if (gd != null)
            {
                return;
            }
            
            gd.LoadGUIDData();
        }
    }
}
