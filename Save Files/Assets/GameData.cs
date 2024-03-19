using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class GameData
{
    private int _health;
    private int _mana;
    private VectorToken _position;
    private VectorToken _rotation;
    public int GetHealth { get { return _health; } }
    public int GetMana { get { return _mana; } }
    public Vector3 GetPosition { get { return _position.GetVector; } }
    public Vector3 GetRotation { get { return _rotation.GetVector; } }

    public GameData(int health, int mana, Vector3 position, Vector3 rotation)
    {
        _health = health;
        _mana = mana;
        _position = new VectorToken(position);
        _rotation = new VectorToken(rotation);
    }
}

[System.Serializable]
public class VectorToken
{
    private float _x;
    private float _y;
    private float _z;

    public Vector3 GetVector { get { return new Vector3(_x, _y, _z); } }

    public VectorToken(Vector3 v)
    {
        _x = v.x;
        _y = v.y;
        _z = v.z;
    }
}