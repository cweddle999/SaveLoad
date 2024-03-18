using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    private int _health;
    private int _mana;

    public int GetHealth { get { return _health; } }
    public int GetMana { get { return _mana; } }

    public GameData(int health, int mana)
    {
        _health = health;
        _mana = mana;
    }
}
