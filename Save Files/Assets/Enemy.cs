using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health;
    public int mana;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            NewBehaviourScript.Save("EnemyData", new GameData(health, mana));
        }


        if (Input.GetKeyDown(KeyCode.L))
        {
            GameData gd = NewBehaviourScript.Load("EnemyData");
            if (gd != null)
            {
                return;
            }

            health = gd.GetHealth;
            mana = gd.GetMana;

        }
    }
}
