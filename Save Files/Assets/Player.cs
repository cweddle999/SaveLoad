using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public int mana;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            NewBehaviourScript.Save("Cody", new GameData(health, mana));
        }


        if (Input.GetKeyDown(KeyCode.L))
        {
            GameData gd = NewBehaviourScript.Load("Cody");
            if (gd != null)
            {
                return;
            }
            
            health = gd.GetHealth;
            mana = gd.GetMana;
        }
    }
}
