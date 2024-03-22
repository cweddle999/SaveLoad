using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Class Player handles the save and load
/// (this script shouldn't be tied to a player script)
/// (use input manager instead)
/// </summary>
public class Player : CharacterGUID
{
    
    // Update is called once per frame
    void Update()
    {
        // loop checks for the key stroke S
        if (Input.GetKeyDown(KeyCode.S))
        {
            // Sends a message to Save Load which will create a new binary file ofd the parsed in name
            // generates a new game data based on the current game state
            // save the game data in the generated file.
            NewBehaviourScript.Save("Cody", new GameData());
        }

        // loop checks for keystroke L
        if (Input.GetKeyDown(KeyCode.L))
        {
            // Send a request to save load to find a file of the parsed in name
            // if the file is not found it will return nothing.
            GameData gd = NewBehaviourScript.Load("Cody");
            // file was not found there for loop will force exit the method.
            if (gd != null)
            {
                return;
            }
            // Send a request to Gamedata to set the values of the store guid objects.
            gd.LoadGUIDData();
        }
    }
}
