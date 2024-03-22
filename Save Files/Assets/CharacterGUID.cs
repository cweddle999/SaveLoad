using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// All characters have health and mana, and are a type of GUID'd object
/// So it has a GUID which can be saved and loaded.
/// </summary>
public class CharacterGUID : GUIDobject
{
    protected int _health;
    protected int _mana;

    public int Health { get { return _health; } set { _health = value; } }
    public int Mana { get { return _mana; }set { _mana = value; } }

}


