using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.UIElements;

[System.Serializable]
public class GameData
{
    private int _health;
    private int _mana;

    private List<GUIDobjecttoken> _guidsInGame = new List<GUIDobjecttoken>();

    public int GetHealth { get { return _health; } }
    public int GetMana { get { return _mana; } }
    public GameData(int health, int mana)
    {
        _health = health;
        _mana = mana;

        foreach (KeyValuePair<string, Transform> item in ObjectRefernce.instance.GetObjectDictionary)
        {
            _guidsInGame.Add(new GUIDobjecttoken(item));
        }

    }
    public void LoadGUIDData()
    {
        for (int i = 0; i < _guidsInGame.Count; i++)
        {
            _guidsInGame[i].LoadGUIDData();
        }
    }
}


[System.Serializable]
public class GUIDobjecttoken
{
    string _guid;
    VectorToken _position;
    VectorToken _rotation;

    public void LoadGUIDData()
    {
        Transform go = ObjectRefernce.instance.ReturnObject(_guid);
        go.position = _position.GetVector;
        go.rotation = Quaternion.Euler(_rotation.GetVector);
    }

    public GUIDobjecttoken(KeyValuePair<string, Transform> go)
    {
        _guid = go.Key;
        _position = new VectorToken(go.Value.position);
        _rotation = new VectorToken(go.Value.rotation.eulerAngles);
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