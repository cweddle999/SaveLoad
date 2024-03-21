using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.UIElements;

[System.Serializable]
public class GameData
{
    private List<GUIDobjecttoken> _guidsInGame = new List<GUIDobjecttoken>();
    public GameData()
    {
        foreach (KeyValuePair<string, Transform> item in ObjectRefernce.instance.GetObjectDictionary)
        {
            //_guidsInGame.Add(new GUIDobjecttoken(item));
            CharacterGUID guid = ObjectRefernce.instance.ReturnObject(item.Key).GetComponent<CharacterGUID>();
            if (guid != null)
            {
                _guidsInGame.Add(new CharacterGUIDToken(guid));
            }
            DodadGUID dodad = ObjectRefernce.instance.ReturnObject(item.Key).GetComponent<DodadGUID>();
            if (dodad != null)
            {
                _guidsInGame.Add(new DodadGUIDToken(dodad));
            }
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
public abstract class GUIDobjecttoken
{
    protected string _guid;
    protected VectorToken _position;
    protected VectorToken _rotation;

    public virtual void LoadGUIDData()
    {
        Transform go = ObjectRefernce.instance.ReturnObject(_guid);
        go.position = _position.GetVector;
        go.rotation = Quaternion.Euler(_rotation.GetVector);
    }
    /*
    public GUIDobjecttoken(KeyValuePair<string, Transform> go)
    {
        _guid = go.Key;
        _position = new VectorToken(go.Value.position);
        _rotation = new VectorToken(go.Value.rotation.eulerAngles);
    }
    */
}
[System.Serializable]
public class CharacterGUIDToken : GUIDobjecttoken
{
    private int _heatlh;
    private int _mana;
   
    public CharacterGUIDToken(CharacterGUID go) 
    {
        _guid = go.getGUID;
        _position = new VectorToken(go.transform.position);
        _rotation = new VectorToken(go.transform.rotation.eulerAngles);
        _heatlh = go.Health;
        _mana = go.Mana;
    }
    
    public override void LoadGUIDData()
    {
        base.LoadGUIDData();
        CharacterGUID go = ObjectRefernce.instance.ReturnObject( _guid).GetComponent<CharacterGUID>();
        go.Health = _heatlh;
        go.Mana = _mana;
    }
}
public class DodadGUIDToken : GUIDobjecttoken
{
    public DodadGUIDToken(DodadGUID go)
    {
        _guid = go.getGUID;
        _position = new VectorToken(go.transform.position);
        _rotation = new VectorToken(go.transform.rotation.eulerAngles);
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